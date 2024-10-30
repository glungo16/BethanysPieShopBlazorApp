using BethanysPieShopBlazorApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace BethanysPieShopBlazorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRegistrationController : Controller
    {
        private readonly ITimeRegistrationRepository _timeRegistrationRepository;

        public TimeRegistrationController(ITimeRegistrationRepository timeRegistrationRepository)
        {
            _timeRegistrationRepository = timeRegistrationRepository;
        }

        //// GET: api/<controller>
        //[HttpGet]
        //public IActionResult GetCountries()
        //{
        //    return Ok(_timeRegistrationRepository.GetAllCountries());
        //}

        // GET api/<controller>/5
        [HttpGet("{employeeId:int}")]
        public async Task<IActionResult> GetTimeRegistrationsForEmployee(int employeeId)
        {
            var timeRegistrations = await _timeRegistrationRepository.GetTimeRegistrationsForEmployee(employeeId);

            if (timeRegistrations == null)
                return NotFound();
            return Ok(timeRegistrations);
        }

        [HttpGet("{employeeId:int}/{pageSize:int}/{start:int}")]
        public async Task<IActionResult> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
        {
            var timeRegistrations = await _timeRegistrationRepository.GetPagedTimeRegistrationsForEmployee(employeeId, pageSize, start);

            if (timeRegistrations == null)
                return NotFound();
            return Ok(timeRegistrations);
        }

        [HttpGet("count/{employeeId:int}")]
        public async Task<IActionResult> GetTimeRegistrationCountForEmployeeId(int employeeId)
        {
            var count = await _timeRegistrationRepository.GetTimeRegistrationCountForEmployeeId(employeeId);

            //if (count == null)
            //    return NotFound();
            return Ok(count);
        }
    }
}
