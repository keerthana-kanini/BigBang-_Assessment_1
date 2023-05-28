using Big_Bang__Assessment_1.DB;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Big_Bang__Assessment_1.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly HotelContext _context;

        public StaffRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetStaffs()
        {
            try
            {
                return await _context.Staffs.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception and return an empty list or rethrow the exception
                // depending on your error handling strategy.
                Console.WriteLine($"Error in GetStaffs: {ex.Message}");
                return new List<Staff>();
            }
        }

        public async Task<Staff> GetStaff(int id)
        {
            try
            {
                return await _context.Staffs.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetStaff: {ex.Message}");
                return null;
            }
        }

        public async Task<Staff> CreateStaff(Staff staff)
        {
            try
            {
                _context.Staffs.Add(staff);
                await _context.SaveChangesAsync();
                return staff;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateStaff: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateStaff(int id, Staff staff)
        {
            try
            {
                if (id != staff.StaffId)
                    return false;

                _context.Entry(staff).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateStaff: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteStaff(int id)
        {
            try
            {
                var staff = await _context.Staffs.FindAsync(id);
                if (staff == null)
                    return false;

                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteStaff: {ex.Message}");
                return false;
            }
        }
    }
}
