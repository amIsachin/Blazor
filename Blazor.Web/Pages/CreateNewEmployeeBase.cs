using Domain.Web.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Web.Pages
{
    public class CreateNewEmployeeBase : ComponentBase
    {
        public EmployeeEntityWeb EmployeeEntityWeb { get; set; } = new();

        protected EditContext editContext;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            this.editContext = new EditContext(EmployeeEntityWeb);
        }


        protected void AddNewEmployee()
        {

        }

    }
}
