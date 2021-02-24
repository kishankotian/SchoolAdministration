using EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using SchoolAdministration.Controllers;
using Service;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace SchoolAdministrationTest
{
    public class SchoolTestController
    {
        private SchoolService _service;
        public static DbContextOptions<SchoolDBContext> dbContextOptions { get; }
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdministrationSystemTest;Integrated Security=True;";
        private readonly SchoolDBContext _context;

        static SchoolTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<SchoolDBContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public SchoolTestController()
        {
            _context = new SchoolDBContext(dbContextOptions);
            TestDataDBInitializer db = new TestDataDBInitializer();
            db.Seed(_context);

            _service = new SchoolService(_context);
        }

        #region GETCOMMONSTUDENT API TEST
        
        [Fact]
        public  void Task_GetCommonStudents_Return_OkResult()
        {
            //Arrange
            var controller = new SchoolController(_service)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            controller.HttpContext.Request.QueryString = new QueryString("?teacher=teacher1@gmail.com");
            
            //Act
            var data = controller.Getcommonstudents();

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetCommonStudents_Return_BadRequestResult()
        {
            //Arrange
            var controller = new SchoolController(_service)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            controller.HttpContext.Request.QueryString = new QueryString("?teacheremail=teacher1@gmail.com");

            //Act
            var data = controller.Getcommonstudents();

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public void Task_GetCommonStudents_Return_NotFoundResult()
        {
            //Arrange
            var controller = new SchoolController(_service)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            controller.HttpContext.Request.QueryString = new QueryString("?teacher=teacher11@gmail.com");

            //Act
            var data = controller.Getcommonstudents();

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public void Task_GetCommonStudents_Return_MatchedResult()
        {
            //Arrange
            var controller = new SchoolController(_service)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            controller.HttpContext.Request.QueryString = new QueryString("?teacher=teacher1@gmail.com");

            //Act
            var data = controller.Getcommonstudents() as OkObjectResult;
            var result = data.Value as StudentListModel;
            var student = result.Students.FirstOrDefault(x=>x == "student1@gmail.com");
            //Assert
            Assert.IsType<OkObjectResult>(data);
            string studentEmail = "student1@gmail.com";
            Assert.Equal(studentEmail, student);
        }
        #endregion GETCOMMONSTUDENT API TEST

        #region GETNOTIFICATIONRECIPIENT API TEST
        [Fact]
        public void Task_GetStudentsForNotification_Return_OkResult()
        {
            //Arrange
            var controller = new SchoolController(_service);
            var notificationRequest = new NotificationModel { 
                Teacher = "teacher1@gmail.com",
                Notification = "hi students! @student5@gmail.com"
            };
            //Act
            var data = controller.GetStudentsForNotification(notificationRequest);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetStudentsForNotification_Return_NotFoundResult()
        {
            //Arrange
            var controller = new SchoolController(_service);
            var notificationRequest = new NotificationModel
            {
                Teacher = "teacher11@gmail.com",
                Notification = "hi students! @student55@gmail.com"
            };
            //Act
            var data = controller.GetStudentsForNotification(notificationRequest);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public void Task_GetStudentsForNotification_Return_MatchedResult()
        {
            //Arrange
            var controller = new SchoolController(_service);
            var notificationRequest = new NotificationModel
            {
                Teacher = "teacher11@gmail.com",
                Notification = "hi students! @student1@gmail.com"
            };
            //Act
            var data = controller.GetStudentsForNotification(notificationRequest) as OkObjectResult;
            var result = data.Value as RecipientModel;
            var student = result.Recipients.FirstOrDefault();
            //Assert
            Assert.IsType<OkObjectResult>(data);
            string studentEmail = "student1@gmail.com";
            Assert.Equal(studentEmail, student);
        }
        #endregion GETNOTIFICATIONRECIPIENT API TEST

        #region REGISTER API TEST
        [Fact]
        public void Task_RegisterStudent_Return_OkResult()
        {
            //Arrange
            var controller = new SchoolController(_service);
            var model = new RegistrationModel
            {
                Teacher = "teacher1@gmail.com",
                Students = new List<string>() { "student12@gmail.com","student13@gmail.com" }
            };
            //Act
            var data = controller.Registration(model);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_RegisterStudent_Return_NotFoundResult()
        {
            //Arrange
            var controller = new SchoolController(_service);
            var model = new RegistrationModel
            {
                Teacher = "teacher6@gmail.com",
                Students = new List<string>() { "student12@gmail.com", "student13@gmail.com" }
            };
            //Act
            var data = controller.Registration(model);

            //Assert
            Assert.IsType<NotFoundObjectResult>(data);
        }

        [Fact]
        public void Task_RegisterStudent_Return_MatchedResult()
        {
            //Arrange
            var controller = new SchoolController(_service)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            }; 
            var model = new RegistrationModel
            {
                Teacher = "teacher4@gmail.com",
                Students = new List<string>() { "student12@gmail.com", "student13@gmail.com" }
            };
            //Act
            var data = controller.Registration(model) as OkObjectResult;
            Assert.IsType<OkObjectResult>(data);

            controller.HttpContext.Request.QueryString = new QueryString("?teacher=teacher4@gmail.com");

            //Act
            var response = controller.Getcommonstudents() as OkObjectResult;
            var result = response.Value as StudentListModel;
            var student = result.Students.FirstOrDefault(x => x == "student12@gmail.com");
            //Assert
            Assert.IsType<OkObjectResult>(response);
            string studentEmail = "student12@gmail.com";
            Assert.Equal(studentEmail, student);
        }
        #endregion REGISTER API TEST

        #region Suspend API TEST
        [Fact]
        public void Task_SuspendStudent_Return_OkResult()
        {
            //Arrange
            var controller = new SchoolController(_service);
            var model = new SuspendModel
            {
                Student = "student6@gmail.com"
            };
            //Act
            var data = controller.SuspendStudent(model);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_SuspendStudent_Return_NotFoundResult()
        {
            //Arrange
            var controller = new SchoolController(_service);
            var model = new SuspendModel
            {
                Student = "student18@gmail.com"
            };
            //Act
            var data = controller.SuspendStudent(model);

            //Assert
            Assert.IsType<NotFoundObjectResult>(data);
        }

        #endregion REGISTER API TEST
    }
}
