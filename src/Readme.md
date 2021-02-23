#Project and Assemblies:
1. Data - To define entity and data model for the application
2. EntityFramework contain the DBcontext configuration for the application
3. Service - Contain the main business logic for all the api
4. SchoolAdministration - Main project where application setup and API routing configuration is done.

#Update SQL connectionstring in appsettings.json as per requirement.

#Configured swagger for testing the API
Running the code will open default url : https://localhost:portnumber/
To open swagger UI append url with swagger as  https://localhost:portnumber/swagger
Swagger UI will list down all APIs along with request sample.

#Below are the set of APIs for school administration
1. API to register one or more students to a specified teacher
	Endpoint: POST /api/register
        Headers: Content-Type: application/json
        Success response status: HTTP 200
        Request body example:
        {
          "teacher": "teacher1@gmail.com"
          "students":
            [
              "student1@gmail.com",
              "student2@gmail.com"
            ]
        }
2. API to retrieve a list of students common to a given list of teachers
	Endpoint: GET /api/commonstudents
        Success response status: HTTP 200
        Request example 1: GET /api/commonstudents?teacher=teacher1%40gmail.com
        Success response body 1:
        {
          "students" :
            [
              "commonstudent1@gmail.com", 
              "commonstudent2@gmail.com",
              "student_only_under_teacher_ken@gmail.com"
            ]
        }
        Request example 1: GET /api/commonstudents?teacher=teacher1%40gmail.com&teacher2%40gmail.com
3. API to suspend a specified student
    Endpoint: POST /api/suspend
    Headers: Content-Type: application/json
    Success response status: HTTP 200
    Request body example:
    {
      "student" : "studentmary@gmail.com"
    }

4. API to retrieve a list of students who can receive a given notification
    Endpoint: POST /api/retrievefornotifications
    Headers: Content-Type: application/json
    Success response status: HTTP 200
    Request body example 1:
    {
      "teacher":  "teacher1@gmail.com",
      "notification": "Hello students! @student1s@gmail.com @student2@gmail.com"
    }
