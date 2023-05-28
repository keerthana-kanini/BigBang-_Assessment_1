using Big_Bang__Assessment_1.Repository;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Big_Bang__Assessment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
