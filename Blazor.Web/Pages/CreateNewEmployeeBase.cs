using Application.Web.Repositories.Interfaces;
using Domain.Web.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System.Net;

namespace Blazor.Web.Pages
{
    public class CreateNewEmployeeBase : ComponentBase
    {
        public EmployeeEntityWeb EmployeeEntityWeb { get; set; } = new();

        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

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

            var authenticationState = await AuthenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                string returnUrl = WebUtility.UrlEncode($"/newEmployee");

                NavigationManager.NavigateTo($"/identity/account/login?returnUrl={returnUrl}");
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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