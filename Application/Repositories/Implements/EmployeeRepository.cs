using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Data.SqlClient;

namespace Application.Repositories.Implements;

public class EmployeeRepository : IEmployeeRepository
{

    /// <summary>
    /// This method is responsible to get all employee from Blazor data base.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<EmployeeEntity>> GetAllEmployees()
    {
        List<EmployeeEntity> _employees = new List<EmployeeEntity>();

        try
        {
            using (SqlConnection conn = new SqlConnection(DataBaseConnection.GetConnectionString()))
            {
                string query = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(query, conn);
                await conn.OpenAsync();

                SqlDataReader dr = await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    EmployeeEntity employee = new EmployeeEntity();

                    employee.EmployeeId = Convert.ToInt32(dr.GetValue(0));
                    employee.Name = dr.GetValue(1).ToString();
                    employee.Age = Convert.ToInt32(dr.GetValue(2));
                    employee.Salary = Convert.ToInt32(dr.GetValue(3));
                    employee.City = dr.GetValue(4).ToString();
                    employee.CreatedOn = Convert.ToDateTime(dr.GetValue(5));

                    _employees.Add(employee);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error occured from employee repository {ex.Message}");
        }

        return _employees;
    }
}
