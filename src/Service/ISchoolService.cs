using Data;
using Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ISchoolService
    {
        APIResponseModel RegisterStudent(RegistrationModel model);
        APIResponseModel SuspendStudent(string studentEmail);
        StudentListModel GetCommonStudents(string request);
    }
}
