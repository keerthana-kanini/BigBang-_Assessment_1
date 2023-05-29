using ClassLibrary.Models;

namespace Big_Bang__Assessment_1.Repository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetRooms();
        Room GetRoomById(int id);
        Room CreateRoom(Room room);
        Room UpdateRoom(int id, Room room);
        void DeleteRoom(int id);
    

        Task<int> GetAvailableRoomCountByHotel(int hotelId);
        Task<IEnumerable<Room>> GetRoomsByHotelAndAvailability(int hotelId, string availability);

    }
}
