using Application.Web.Repositories.Interfaces;
using Domain.Web.Entities;
using System.Net.Http.Json;

namespace Application.Web.Repositories.Implements;

public class EmployeeRepository : IEmployeeRepository
{
    #region HttpClient
    private readonly HttpClient _httpClient;

    public EmployeeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    #endregion

    /// <summary>
    /// This method is resposible for get all employees from API.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<EmployeeEntityWeb>> GetAllEmployees()
    {
        return await _httpClient.GetFromJsonAsync<EmployeeEntityWeb[]>("api/employee/getallemployees");
    }


    /// <summary>
    /// This method is resposible for get employees by id from API.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<EmployeeEntityWeb> GetEmployeeById(int id)
    {
        return await _httpClient.GetFromJsonAsync<EmployeeEntityWeb>($"api/employee/GetEmployeeById/{id}");
    }


    /// <summary>
    /// This method is resposible for updated existing employee from API.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="employeeEntityWeb"></param>
    /// <returns></returns>
    public async Task<bool> UpdateEmployee(int id, EmployeeEntityWeb employeeEntityWeb)
    {
        HttpResponseMessage isUpdated = await _httpClient.PutAsJsonAsync($"api/employee/UpdateEmployee/" + id, employeeEntityWeb);

        if (isUpdated.IsSuccessStatusCode is true)
        {
            return true;
        }

        return false;
    }


    /// <summary>
    /// This method is resposible for delete existing employee from API.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteEmployee(int id)
    {
        HttpResponseMessage isDeleted = await _httpClient.DeleteAsync($"api/employee/DeleteEmployee/{id}");

        if (isDeleted.IsSuccessStatusCode is true)
        {
            return true;
        }

        return false;
    }
}