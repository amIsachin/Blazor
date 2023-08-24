using Application.Web.Repositories.Interfaces;
using Domain.Web.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Web.Pages
{
    public class CreateNewEmployeeBase : ComponentBase
    {
        public EmployeeEntityWeb EmployeeEntityWeb { get; set; } = new();

        [Inject]
        public IEmployeeRepository EmployeeRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected EditContext editContext;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            this.editContext = new EditContext(EmployeeEntityWeb);
        }


        protected async Task AddNewEmployee()
        {
            var isInserted = await EmployeeRepository.AddNewEmployee(EmployeeEntityWeb);

            if (isInserted is true)
            {
                NavigationManager.NavigateTo("/");
            }



        }

    }
}
