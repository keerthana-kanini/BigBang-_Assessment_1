using Big_Bang__Assessment_1.Repository;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Big_Bang__Assessment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepo;

        public HotelsController(IHotelRepository hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotels = await _hotelRepo.GetAllHotelsAsync();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotel = await _hotelRepo.GetHotelByIdAsync(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostHotels([FromBody] Hotel hotel)
        {
            try
            {
                if (hotel == null)
                {
                    return BadRequest();
                }
                var addedHotel = await _hotelRepo.PostHotelsAsync(hotel);
                return CreatedAtAction(nameof(GetHotelById), new { id = addedHotel.Hotel_Id }, addedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, [FromBody] Hotel hotel)
        {
            try
            {
                if (hotel == null || hotel.Hotel_Id != id)
                {
                    return BadRequest();
                }
                var updatedHotel = await _hotelRepo.PutHotelAsync(id, hotel);
                if (updatedHotel == null)
                {
                    return NotFound();
                }
                return Ok(updatedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelHotels(int id)
        {
            try
            {
                var hotel = await _hotelRepo.DelHotelsAsync(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("search/location")]
        public IActionResult SearchHotels(string location)
        {
            try
            {
                var hotels = _hotelRepo.SearchHotelsbylocation(location);
                return Ok(hotels);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while searching hotels.");
            }
        }

        [HttpGet("search/Pricerange")]
        public IEnumerable<Hotel> SearchHotelsByPriceRange(int minPrice, int maxPrice)
        {
            try
            {
                return _hotelRepo.SearchHotelsByPriceRange(minPrice, maxPrice);
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                throw new Exception("An error occurred while searching hotels by price range.", ex);
            }
        }


    }
}
