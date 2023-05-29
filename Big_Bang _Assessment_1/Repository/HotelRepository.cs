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
        public IEnumerable<Hotel> SearchHotels(string location)
        {
            try
            {
                IQueryable<Hotel> query = _projectcontext.Hotels.Include(x => x.Rooms);

                // Apply filter based on location
                if (!string.IsNullOrEmpty(location))
                {
                    query = query.Where(x => x.Hotel_Location.Contains(location));
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
               
                throw new Exception("An error occurred while searching hotels.", ex);
            }
        }

        public IEnumerable<Hotel> SearchHotelsbylocation(string location)
        {
            IQueryable<Hotel> query = _projectcontext.Hotels.Include(x => x.Rooms);

            // Apply filter based on location
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Hotel_Location.Contains(location));
            }

            return query.ToList();
        }

        public IEnumerable<Hotel> SearchHotelsByPriceRange(int minPrice, int maxPrice)
        {
            try
            {
                return _projectcontext.Hotels
                    .Where(x => x.Hotel_Price >= minPrice && x.Hotel_Price <= maxPrice)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                throw new Exception("An error occurred while searching rooms by price range.", ex);
            }
        }


        
    }


}

