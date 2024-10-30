using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopBlazorApi.Models
{
    public interface ITimeRegistrationRepository
    {

        Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId);
        Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start);
        Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId);
    }
}
