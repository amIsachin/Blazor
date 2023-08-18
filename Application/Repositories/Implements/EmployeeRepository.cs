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


    /// <summary>
    /// This method is responsible to get employee by id from Blazor data base.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<EmployeeEntity> GetEmployeeById(int id)
    {
        EmployeeEntity employee = new EmployeeEntity();
        using SqlConnection conn = new SqlConnection(DataBaseConnection.GetConnectionString());
        string query = $"SELECT * FROM Employee WHERE EmployeeId = {id}";
        using SqlCommand cmd = new SqlCommand(query, conn);
        await conn.OpenAsync();
        cmd.Parameters.AddWithValue("EmployeeId", id);

        SqlDataReader dr = await cmd.ExecuteReaderAsync();

        while (await dr.ReadAsync())
        {
            employee.EmployeeId = dr.GetInt32(0);
            employee.Name = dr.GetString(1);
            employee.Age = dr.GetInt32(2);
            employee.Salary = dr.GetInt32(3);
            employee.City = dr.GetString(4);
            employee.CreatedOn = dr.GetDateTime(5);
        }

        return employee;

    }


    /// <summary>
    /// This method is responsible to to update existing employee.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="employee"></param>
    /// <returns></returns>
    public async Task<bool> UpdateEmployee(int id, EmployeeEntity employee)
    {
        using SqlConnection conn = new SqlConnection(DataBaseConnection.GetConnectionString());
        string query = $"UPDATE Employee SET Name = '{employee.Name}', Age = {employee.Age}, Salary = {employee.Salary}, City = '{employee.City}' WHERE EmployeeId = {id}";
        using SqlCommand cmd = new SqlCommand(query, conn);
        await conn.OpenAsync();
        bool isUpdated = await cmd.ExecuteNonQueryAsync() > 0;

        if (isUpdated is true)
        {
            return true;
        }

        return false;
    }
}
