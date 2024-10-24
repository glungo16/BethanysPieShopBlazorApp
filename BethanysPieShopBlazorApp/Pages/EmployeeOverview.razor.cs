using BethanysPieShopBlazorApp.Services;
using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace BethanysPieShopBlazorApp.Pages
{
    public partial class EmployeeOverview
    {
        // one method to do api requests is to inject HttpClient directly in the
        // components like here ------ would also need to configure HttpClient in Program.cs
        // Although this works, it is recommended to have components lightweight
        // and have HttpClient in its own class -> use http client factory

        //[Inject]
        //public HttpClient HttpClient { get; set; }

        //protected async override Task OnInitializedAsync()
        //{
        //    var data = await HttpClient.GetFromJsonAsync<List<Employee>>
        //        ("https://localhost:7039/api/Employee");
        //}

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        public List<Employee> Employees { get; set; } = default!;

        private Employee? _selectedEmployee;

        private string Title = "Employee overview";
        private string Description = "An overview of all employees";


        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees(false)).ToList();
        }

        // used for local mock dataset
        //protected override void OnInitialized()
        //{
        //    Employees = MockDataService.Employees!;
        //}


        public void ShowQuickViewPopup(Employee employee)
        {
            _selectedEmployee = employee;
        }

    }
}
