using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemowithEF1.Entities;
using WebAPIDemowithEF1.Repositories;
namespace WebAPIDemowithEF1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IActionResult GetEmployees()
        {
            EmployeeRepository obj = new EmployeeRepository();
            var result = obj.GetEmployees();
            return Ok(result);

        }
    }
}