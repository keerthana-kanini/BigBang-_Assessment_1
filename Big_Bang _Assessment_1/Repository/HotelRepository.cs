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
        public IEnumerable<Hotel> SearchHotels(string location, int? minPrice, int? maxPrice, string amenities)
        {
            try
            {
                IQueryable<Hotel> query = _projectcontext.Hotels.Include(x => x.Rooms);

                // Apply filters
                if (!string.IsNullOrEmpty(location))
                {
                    query = query.Where(x => x.Hotel_Location.Contains(location));
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(x => x.Hotel_Price >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(x => x.Hotel_Price <= maxPrice.Value);
                }

                if (!string.IsNullOrEmpty(amenities))
                {
                    query = query.Where(x => x.Hotel_Amenities.Contains(amenities));
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while searching hotels.", ex);
            }
        }

        public int GetAvailableRoomCount(int hotelId)
        {
            try
            {
                var hotel = _projectcontext.Hotels.Include(x => x.Rooms).FirstOrDefault(x => x.Hotel_Id == hotelId);
                if (hotel == null)
                {
                    throw new ArgumentException("Invalid hotel ID.");
                }

                return hotel.Rooms.Count(r => int.Parse(r.Room_Availability) > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving available room count.", ex);
            }
        }

        // Existing methods...
    }


}

