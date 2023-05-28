using ClassLibrary.Models;

namespace Big_Bang__Assessment_1.Repository
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetStaffs();
        Task<Staff> GetStaff(int id);
        Task<Staff> CreateStaff(Staff staff);
        Task<bool> UpdateStaff(int id, Staff staff);
        Task<bool> DeleteStaff(int id);
    }
}
