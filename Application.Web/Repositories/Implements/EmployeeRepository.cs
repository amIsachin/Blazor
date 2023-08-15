using Application.Web.Repositories.Interfaces;
using Domain.Web.Entities;
using System.Net.Http.Json;

namespace Application.Web.Repositories.Implements;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly HttpClient _httpClient;

    public EmployeeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<EmployeeEntityWeb>> GetAllEmployees()
    {
        return await _httpClient.GetFromJsonAsync<EmployeeEntityWeb[]>("api/employee/getallemployees");
    }
}
