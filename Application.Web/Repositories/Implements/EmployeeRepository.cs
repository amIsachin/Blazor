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
}