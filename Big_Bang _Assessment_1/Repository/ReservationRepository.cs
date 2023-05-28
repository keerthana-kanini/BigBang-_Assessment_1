using Big_Bang__Assessment_1.DB;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Big_Bang__Assessment_1.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelContext _context;

        public ReservationRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservation(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<int> CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation.Reservation_Id;
        }

        public async Task<int> UpdateReservation(int id, Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return 0; // Indicate that the reservation was not found
                }
                else
                {
                    throw;
                }
            }
            return 1; // Indicate success
        }

        public async Task<int> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
                return 0; // Indicate that the reservation was not found

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return 1; // Indicate success
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Reservation_Id == id);
        }
    }
}
