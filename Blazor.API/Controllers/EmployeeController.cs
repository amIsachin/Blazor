using Application.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region DependencyInjection
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion


        /// <summary>
        /// This method is responsible fro retreive all employee from *Blazor database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetAllEmployees();

                if (employees is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while fetching the all employees from the Blazor database {employees}");
                }

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while fetching the all employees from the Blazor database {ex.Message}");
            }
        }

        /// <summary>
        /// This method is responsible fro retreive employee by id from *Blazor database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeeById(id);

                if (employees is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while fetching the all employees from the Blazor database {employees}");
                }

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while fetching the all employees from the Blazor database {ex.Message}");
            }
        }


    }
}