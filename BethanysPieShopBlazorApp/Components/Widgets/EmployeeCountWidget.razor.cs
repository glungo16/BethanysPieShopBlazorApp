﻿using BethanysPieShopHRM.App.Models;

namespace BethanysPieShopBlazorApp.Components.Widgets
{
    public partial class EmployeeCountWidget
    {
        public int EmployeeCounter { get; set; }

        protected override void OnInitialized()
        {
            EmployeeCounter = MockDataService.Employees.Count;
        }
    }
}
