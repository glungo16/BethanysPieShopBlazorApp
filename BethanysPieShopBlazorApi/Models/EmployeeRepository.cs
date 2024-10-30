using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopBlazorApi.Models
{
    public class EmployeeRepository : IEmployeeRepository//, IDisposable
    {


        //private readonly IDbContextFactory<AppDbContext> _contextFactory;

        //public EmployeeRepository(IDbContextFactory<AppDbContext> contextFactory)
        //{
        //    _contextFactory = contextFactory;
        //}

        //public async Task RunBackgroundTaskAsync()
        //{
        //    using var context = _contextFactory.CreateDbContext();
        //    // Perform database operations
        //    var products = await context.Products.ToListAsync();
        //}


        private readonly AppDbContext _appDbContext;
        private Random random = new Random();

        //public EmployeeRepository(IDbContextFactory<AppDbContext> contextFactory)
        //{
        //    _appDbContext = contextFactory.CreateDbContext();
        //}

        //public void Dispose()
        //{
        //    _appDbContext.Dispose();
        //}

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appDbContext.Employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _appDbContext.Employees.FirstOrDefault(c => c.EmployeeId == employeeId);
        }

        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (foundEmployee != null)
            {
                foundEmployee.CountryId = employee.CountryId;
                foundEmployee.MaritalStatus = employee.MaritalStatus;
                foundEmployee.BirthDate = employee.BirthDate;
                foundEmployee.City = employee.City;
                foundEmployee.Email = employee.Email;
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.Gender = employee.Gender;
                foundEmployee.PhoneNumber = employee.PhoneNumber;
                foundEmployee.Smoker = employee.Smoker;
                foundEmployee.Street = employee.Street;
                foundEmployee.Zip = employee.Zip;
                foundEmployee.JobCategoryId = employee.JobCategoryId;
                foundEmployee.Comment = employee.Comment;
                foundEmployee.ExitDate = employee.ExitDate;
                foundEmployee.JoinedDate = employee.JoinedDate;
                foundEmployee.Longitude = employee.Longitude;
                foundEmployee.Latitude = employee.Latitude;
                foundEmployee.ImageContent = employee.ImageContent;
                foundEmployee.ImageName = employee.ImageName;
                foundEmployee.ImagePath = employee.ImagePath;

                _appDbContext.SaveChanges();

                return foundEmployee;
            }

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.Employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }

        
    }
}
