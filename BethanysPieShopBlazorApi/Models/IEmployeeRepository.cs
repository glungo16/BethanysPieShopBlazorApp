﻿using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopBlazorApi.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int employeeId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        //IEnumerable<EmployeeListModel> GetLongEmployeeList();
        //IEnumerable<EmployeeListModel> GetTakeLongEmployeeList(int request, int count);
    }
}
