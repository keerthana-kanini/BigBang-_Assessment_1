using Big_Bang__Assessment_1.Repository;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Big_Bang__Assessment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _repository;

        public ReservationsController(IReservationRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservations = await _repository.GetReservations();
            return Ok(reservations);
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _repository.GetReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return reservation;
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Reservation_Id)
            {
                return BadRequest();
            }
            var result = await _repository.UpdateReservation(id, reservation);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            var id = await _repository.CreateReservation(reservation);
            return CreatedAtAction("GetReservation", new { id }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var result = await _repository.DeleteReservation(id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

