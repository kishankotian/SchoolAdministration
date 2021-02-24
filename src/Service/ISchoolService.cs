using Model;

namespace Service
{
    public interface ISchoolService
    {
        APIResponseModel RegisterStudent(RegistrationModel model);
        APIResponseModel SuspendStudent(string studentEmail);
        StudentListModel GetCommonStudents(string request);
        RecipientModel GetNotificationRecipients(NotificationModel model);
    }
}
