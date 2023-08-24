using Domain.Web.Entities;

namespace Application.Web.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {

        /// <summary>
        /// This method is resposible for get all employees from API.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EmployeeEntityWeb>> GetAllEmployees();


        /// <summary>
        /// This method is resposible for get employees by id from API.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmployeeEntityWeb> GetEmployeeById(int id);


        /// <summary>
        /// This method is resposible for updated existing employee from API.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeEntityWeb"></param>
        /// <returns></returns>
        Task<bool> UpdateEmployee(int id, EmployeeEntityWeb employeeEntityWeb);


        /// <summary>
        /// This method is resposible for delete existing employee from API.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteEmployee(int id);

        Task<bool> AddNewEmployee(EmployeeEntityWeb employeeEntityWeb);
    }
}
