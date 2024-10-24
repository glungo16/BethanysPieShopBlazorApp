﻿using BethanysPieShopBlazorApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace BethanysPieShopBlazorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_countryRepository.GetAllCountries());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryRepository.GetCountryById(id);

            if (country == null)
                return NotFound();
            return Ok(country);
        }
    }
}
