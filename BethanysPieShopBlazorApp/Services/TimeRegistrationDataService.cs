using BethanysPieShopHRM.Shared.Domain;
using System.Text.Json;

namespace BethanysPieShopBlazorApp.Services
{
    public class TimeRegistrationDataService : ITimeRegistrationDataService
    {

        private readonly HttpClient _httpClient;

        public TimeRegistrationDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
        {

            try
            {
                return (await JsonSerializer.DeserializeAsync<List<TimeRegistration>>
                        (await _httpClient.GetStreamAsync($"api/timeregistration/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }))!;
            }

  
	        catch (Exception e)
	        {

		        throw new Exception(e.Message);
	        }
        }
        public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
        {

            return (await JsonSerializer.DeserializeAsync<List<TimeRegistration>>
                (await _httpClient.GetStreamAsync($"api/timeregistration/{employeeId}/{pageSize}/{start}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }))!;
        }

        public async Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId)
        {

            return (await JsonSerializer.DeserializeAsync<int>
                (await _httpClient.GetStreamAsync($"api/timeregistration/count/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }))!;
        }


        //public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
        //{
        //    return await _timeRegistrationRepository.GetTimeRegistrationsForEmployee(employeeId);
        //}

        //public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
        //{
        //    return await _timeRegistrationRepository.GetPagedTimeRegistrationsForEmployee(employeeId, pageSize, start);
        //}

        //public async Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId)
        //{
        //    return await _timeRegistrationRepository.GetTimeRegistrationCountForEmployeeId(employeeId);
        //}
    }
}
