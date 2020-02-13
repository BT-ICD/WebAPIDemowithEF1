using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemowithEF1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

/// <summary>
/// Learn about NLog - https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-3
/// </summary>
namespace WebAPIDemowithEF1.Controllers
{
    /// <summary>
    /// [Route("api/[Controller]/[action]")] changed from [Route("api/[Controller]")] to invoke by method name
    /// </summary>
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly LearningDBContext _context;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(LearningDBContext context, ILogger<StudentsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            _logger.LogTrace("This is Trace");
            _logger.LogDebug("This is debug");
            _logger.LogInformation("This is information");
            _logger.LogWarning("This is warning");
            _logger.LogError("This is error");
            _logger.LogCritical("This is critical");

            //throw new Exception("Custom Exception for testing ");
            _logger.LogInformation(1, "Hello this is GetStudens method");
            //var result = _context.Students.ToList();
            //return Ok(result);

            //Alternate way to return list as well as with total number of records in Response Header
            //var result = new ObjectResult(_context.Students)
            //{
            //    StatusCode = (int)HttpStatusCode.OK
            //};

            var result = _context.Students_GetAllStudents.FromSqlRaw<StudentDTO> ("Students_GetAll").ToList();
            
            //To add additional information to request header
            Request.HttpContext.Response.Headers.Add("X-Total-Count", _context.Students.ToList().Count.ToString());
            _logger.LogInformation(1, "Result Count: " + result.Count);
            return Ok(result);
        }


        //Following attribute [HttpGet("{Id}")] - defines argument variable initialize from URL. Not received value when pass as a paramenter. Without this user need to pass argument using query string variable

        //[HttpGet("{Id}")]
        [Route("{id:int}")] //Allows to read values from URL
        public IActionResult StudentsById(int Id)
        {
            var result = _context.Students.Where(m => m.ID == Id).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("{ID:int}/{SName}")]
        public IActionResult StudentByIdAndName(int Id, string SName)
        {
            //To call Store procedure https://docs.microsoft.com/en-us/ef/core/querying/raw-sql
            var list = _context.Students_GetAllStudents.FromSqlRaw<StudentDTO>("Execute Students_GetByIDAndName {0},{1}", Id, SName).ToList();
            var result = list.FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddStudent(Student obj)
        {
            _context.Students.Add(obj);
            _context.SaveChanges();
            return Ok(obj);
        }
    }
}