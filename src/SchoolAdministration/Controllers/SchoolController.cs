using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAdministration.Helper;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAdministration.Controllers
{
    [Route("api")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolService _service;

        public SchoolController(SchoolService service)
        {
            _service = service;
        }

        /// <summary>
        /// To retrieve a list of students who can receive a given notification
        /// </summary>
        /// <param name="model"></param>
        /// <returns>list of student email</returns>
        // GET: api/retrievefornotifications
        [HttpPost("retrievefornotifications")]
        public IActionResult GetStudentsForNotification([FromBody] NotificationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _service.GetNotificationRecipients(model);
                    return Ok(result);
                }
                return BadRequest(new { Message = ErrorHelpers.GetErrors(ModelState) });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To retrieve a list of students common to a given list of teachers
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns>list of student email</returns>
        // GET api/commonstudents        
        [HttpGet("commonstudents")]
        public IActionResult Getcommonstudents([FromQuery]string teacher)
        {
            try
            {
                string requestQuery = HttpContext.Request.Query[Constant.TeacherQueryString].ToString();
                if (string.IsNullOrEmpty(requestQuery)) return BadRequest();
                var result = _service.GetCommonStudents(requestQuery);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// to register one or more students to a specified teacher
        /// </summary>
        /// <param name="model"></param>
        /// <returns>response status code and message</returns>
        // POST api/register
        [HttpPost("register")]
        public IActionResult Registration([FromBody] RegistrationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _service.RegisterStudent(model);
                    if (result?.Status == APIResponse.Success)
                        return Ok(result);
                    return BadRequest(new { Message = result?.Message });
                }
                return BadRequest(new { Message = ErrorHelpers.GetErrors(ModelState) });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To suspend a specified student
        /// </summary>
        /// <param name="model"></param>
        /// <returns>response status</returns>
        // DELETE api/suspend        
        [HttpPost("suspend")]
        public IActionResult SuspendStudent([FromBody] SuspendModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _service.SuspendStudent(model.Student);
                    if(result.Status == APIResponse.Success)
                        return Ok(result);
                    else if (result.Status == APIResponse.AlreadyExist)
                        return StatusCode(StatusCodes.Status304NotModified, new ResponseModel { Message = result.Message });
                    else
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseModel { Message = result.Message });
                }
                return BadRequest(new { Message = ErrorHelpers.GetErrors(ModelState) });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
