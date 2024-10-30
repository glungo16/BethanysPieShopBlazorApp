using BethanysPieShopBlazorApp.Services;
using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Runtime.CompilerServices;

namespace BethanysPieShopBlazorApp.Pages
{
    public partial class EmployeeDetail
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ITimeRegistrationDataService? TimeRegistrationDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public List<Marker> MapMarkers { get; set; } = new List<Marker>();
        public List<TimeRegistration> TimeRegistrations { get; set; } = [];

        private float itemHeight = 50; // how many pixels a single item will need
        protected int queryableCount = 0;

        public PaginationState pagination = new() { ItemsPerPage = 10 };

        protected IQueryable<TimeRegistration>? itemsQueryable;

        protected async override Task OnInitializedAsync()
        {
            //Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));

            //return base.OnInitializedAsync();

            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            

            if (Employee.Longitude.HasValue && Employee.Latitude.HasValue)
            {
                MapMarkers = new List<Marker>
                {
                    new Marker
                    {
                        Description = $"{Employee.FirstName} {Employee.LastName}",
                        ShowPopup = false,
                        X = Employee.Longitude.Value,
                        Y = Employee.Latitude.Value
                    }
                };
            }

            TimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationsForEmployee(int.Parse(EmployeeId));

            itemsQueryable = (await
                TimeRegistrationDataService.GetTimeRegistrationsForEmployee(int.Parse(EmployeeId))).AsQueryable();
        }

        public async ValueTask<ItemsProviderResult<TimeRegistration>> LoadTimeRegistrations(ItemsProviderRequest request)
        {
            int totalNumberOfTimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationCountForEmployeeId(int.Parse(EmployeeId));

            var numberOfTimeRegistrations = Math.Min(request.Count, totalNumberOfTimeRegistrations - request.StartIndex);
            var listItems = await TimeRegistrationDataService.GetPagedTimeRegistrationsForEmployee(int.Parse(EmployeeId), numberOfTimeRegistrations, request.StartIndex);

            return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);
        }


        //protected async override Task OnAfterRenderAsync(bool firstRender)
        //{
        //    TimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationsForEmployee(int.Parse(EmployeeId));
        //}
    }
}
