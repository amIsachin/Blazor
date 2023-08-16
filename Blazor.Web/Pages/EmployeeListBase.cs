using Application.Web.Repositories.Interfaces;
using BlazorBootstrap;
using Domain.Web.Entities;
using Microsoft.AspNetCore.Components;

namespace Blazor.Web.Pages;

public class EmployeeListBase : ComponentBase
{
    [Inject]
    public IEmployeeRepository EmployeeRepository { get; set; }

    [Inject]
    protected PreloadService PreloadService { get; set; }

    public IEnumerable<EmployeeEntityWeb> EmployeeEntityWeb { get; set; }

  

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        await Task.Run(LoadEmployee);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstRender"></param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        PreloadService.Show(SpinnerColor.Primary);

        await Task.Run(LoadEmployee);

        PreloadService.Hide();
    }

    /// <summary>
    /// This method is responsible to load employee from api.
    /// </summary>
    /// <returns></returns>
    private async Task LoadEmployee()
    {
        EmployeeEntityWeb = (await EmployeeRepository.GetAllEmployees()).ToList();
    }
    

    /// <summary>
    /// This method is responsible to display list of employee using grid.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    protected async Task<GridDataProviderResult<EmployeeEntityWeb>> EmployeesDataProvider(GridDataProviderRequest<EmployeeEntityWeb> request)
    {
        return await Task.FromResult(request.ApplyTo(EmployeeEntityWeb));
    }

  
}
