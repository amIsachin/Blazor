using Domain.Web.Entities;

namespace Application.Web.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntityWeb>> GetAllEmployees();
    }
}
