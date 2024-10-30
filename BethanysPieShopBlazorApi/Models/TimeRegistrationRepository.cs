using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopBlazorApi.Models
{
    public class TimeRegistrationRepository : ITimeRegistrationRepository
    {
        private readonly AppDbContext _appDbContext;

        public TimeRegistrationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
        {
            return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).OrderBy(t => t.StartTime).ToListAsync();
        }

        public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
        {
            return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).OrderBy(t => t.StartTime).Skip(start).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId)
        {
            return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).CountAsync();
        }

    }
}
