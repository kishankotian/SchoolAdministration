using Data;
using Data.EntityModel;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolDBContext _context;

        public SchoolService(SchoolDBContext context)
        {
            _context = context;
        }
        public APIResponseModel RegisterStudent(RegistrationModel model)
        {
            try
            {
                string responseMessage = string.Empty;
                if (model != null)
                {
                    var teacherData = _context.Teachers.FirstOrDefault(x=>x.Email == model.Teacher);
                    if (teacherData != null)
                    {
                        List<Student> students = new List<Student>();
                        List<Registration> registrationList = new List<Registration>();
                        foreach(var item in model.Students)
                        {
                            students.Add(AddOrUpdateStudent(item, teacherData.Email));
                            bool isStudentRegisteredUnderSameTeacher = _context.Registrations.Any(x => x.IsActive == true && x.StudentEmail == item && x.RegisteredBy == teacherData.Email);
                            if (isStudentRegisteredUnderSameTeacher)
                                responseMessage += string.Join("\r\n",string.Format(GlobalResource.EmailAlreadyRegistered, item));
                            else
                            {
                                registrationList.Add(new Registration { StudentEmail = item.ToString(), RegisteredBy = teacherData.Email, Created = DateTime.Now, CreatedBy = teacherData.Email, IsActive = true });
                                responseMessage += string.Join("\r\n", string.Format(GlobalResource.RegisteredSuccessful,item));
                            }

                        }
                        students.ForEach( item => _context.Students.AddOrUpdate(item));
                        registrationList.ForEach(register => _context.Registrations.AddOrUpdate(register));
                        _context.SaveChanges();
                        return new APIResponseModel { Status = APIResponse.Success, Message = responseMessage };
                    }
                    return new APIResponseModel { Status = APIResponse.Failed, Message = GlobalResource.TeacherEmailNotExist };
                }
                return new APIResponseModel { Status = APIResponse.Failed, Message = GlobalResource.InvalidModelData };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Student AddOrUpdateStudent(string studentEmail, string teacherEmail)
        {
            try
            {
                var studentData = _context.Students.FirstOrDefault(x=> x.Email == studentEmail);
                if(studentData != null)
                {
                    studentData.IsActive = true;
                    studentData.Modified = DateTime.Now;
                    studentData.ModifiedBy = teacherEmail;
                }
                else
                {
                    studentData = new Student {
                        IsActive = true,
                        Email = studentEmail,
                        Created = DateTime.Now,
                        CreatedBy = teacherEmail
                    };
                }
                return studentData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public APIResponseModel SuspendStudent(string studentEmail)
        {
            try
            {
                var studentData = _context.Students.FirstOrDefault(x=>x.Email == studentEmail);
                if(studentData != null && studentData.IsActive == true)
                {
                    studentData.IsActive = false;
                    studentData.Modified = DateTime.Now;
                    _context.SaveChanges();
                    return new APIResponseModel { Status = APIResponse.Success, Message = studentEmail + GlobalResource.StudentSuspended };
                }
                else if(studentData != null && studentData.IsActive == false)
                    return new APIResponseModel { Status = APIResponse.AlreadyExist, Message = studentEmail + GlobalResource.IsAlreadySuspended };
                else
                    return new APIResponseModel { Status = APIResponse.Unavailable, Message = GlobalResource.StudentRecordNotFound };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public StudentListModel GetCommonStudents(string request)
        {
            try
            {
                List<string> teacherEmails = request.Split(",").ToList();
                IEnumerable<string> studentList = new List<string>();
                foreach(var teacher in teacherEmails)
                {
                    var registeredStudents = _context.Registrations.Where(x => x.RegisteredBy == teacher).Select(x => x.StudentEmail).ToList();
                    if (studentList.Count() == 0)
                        studentList = registeredStudents;
                    studentList = registeredStudents.Intersect(studentList);
                }
                return new StudentListModel { Students = studentList.Distinct() };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public RecipientModel GetNotificationRecipients(NotificationModel model)
        {
            try
            {
                List<string> registeredStudents = _context.Registrations.Where(x => x.RegisteredBy == model.Teacher).Select(x=>x.StudentEmail).ToList();
                List<string> notificationEmails = model.Notification.Split(" ").Where(x=> x.StartsWith("@")).Select(x=>x.Remove(0,1)).ToList();
               
                notificationEmails = (registeredStudents.Union(notificationEmails)).ToList();
                var activeStudents = _context.Students.Where(x => x.IsActive == true && notificationEmails.Contains(x.Email)).Select(x => x.Email).ToList();


                return new RecipientModel { Recipients = activeStudents };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
