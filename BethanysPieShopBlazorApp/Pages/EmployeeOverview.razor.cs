using BethanysPieShopHRM.App.Models;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopBlazorApp.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;

        private Employee? _selectedEmployee;

        private string Title = "Employee overview";
        private string Description = "An overview of all employees";
        protected override void OnInitialized()
        {
            Employees = MockDataService.Employees!;
        }

        public void ShowQuickViewPopup(Employee employee)
        {
            _selectedEmployee = employee;
        }

    }
}
