using CitiesApi.Models;
using CitiesApi.Paging;
using CitiesApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICityRepository _cityRepository;
        public CitiesController(ICityRepository cityRepository) 
        {
            _cityRepository=cityRepository; 
        }

        //api/City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCity([FromQuery] PagingParameters pagingParameters)
        {
            return await _cityRepository.GetCities(pagingParameters);
        }
        [HttpGet("{id}")]
        public ActionResult<City> GetCityById(int id)
        {
            var city = _cityRepository.GetCity(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]

        public ActionResult<City> CreateCity([FromBody]City city)
        {
            if (city == null)
            {
                return BadRequest("City object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid mode object");
            }
            _cityRepository.CreateCity(city);
            return Ok(CreatedAtRoute("CityId", new {id=city.Id},city));
        }

        [HttpPut("{id}")]

        public IActionResult UpdateCity(int id,[FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest("City object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid mode object");
            }
            var dbcty = _cityRepository.GetCity(id);
            if (!dbcty.Id.Equals(id))
            {
                return NotFound();
            }
            _cityRepository.UpdateCity(city);
            return NoContent();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteCity(int id)
        {
            var dbcty = _cityRepository.GetCity(id);
            if (!dbcty.Id.Equals(id))
            {
                return NotFound();
            }
            _cityRepository.DeleteCity(dbcty);
            return NoContent();
        }


    }
}
