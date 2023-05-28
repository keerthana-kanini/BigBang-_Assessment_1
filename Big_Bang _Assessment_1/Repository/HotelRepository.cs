using Big_Bang__Assessment_1.DB;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Big_Bang__Assessment_1.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _projectcontext;

        public HotelRepository(HotelContext context)
        {
            _projectcontext = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            try
            {
                return await _projectcontext.Hotels.Include(x => x.Rooms).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            try
            {
                return await _projectcontext.Hotels.Include(x => x.Rooms).FirstOrDefaultAsync(x => x.Hotel_Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> PostHotelsAsync(Hotel hotel)
        {
            try
            {
                _projectcontext.Hotels.Add(hotel);
                await _projectcontext.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> PutHotelAsync(int id, Hotel hotel)
        {
            try
            {
                _projectcontext.Entry(hotel).State = EntityState.Modified;
                await _projectcontext.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Hotel> DelHotelsAsync(int id)
        {
            try
            {
                Hotel del = await _projectcontext.Hotels.FirstOrDefaultAsync(x => x.Hotel_Id == id);
                _projectcontext.Hotels.Remove(del);
                await _projectcontext.SaveChangesAsync();
                return del;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
