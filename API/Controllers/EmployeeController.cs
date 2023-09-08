using API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {

            _employeeService = employeeService;

        }
        // GET: api/<UsersController>
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployees();

                if (employees != null)
                    return Ok(employees);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return NoContent();
        }

        //get employee by id 
        [HttpGet]
        [Route("GetEmployee/{employeeId}")]
        public IActionResult GetEmployeeById(int employeeId)
        {
            try
            {
                var employees = _employeeService.GetEmployees().Where(a => a.Id == employeeId);

                if (employees != null)
                    return Ok(employees);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return NoContent();
        }
    }
}
