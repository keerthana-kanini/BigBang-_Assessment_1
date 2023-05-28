using Big_Bang__Assessment_1.DB;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Big_Bang__Assessment_1.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext hrContext;

        public RoomRepository(HotelContext con)
        {
            hrContext = con;
        }

        public Room GetRoomById(int id)
        {
            try
            {
                return hrContext.Rooms.FirstOrDefault(x => x.Room_Id == id);
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw new Exception("Error occurred while retrieving room by ID.", ex);
            }
        }

        public IEnumerable<Room> GetRooms()
        {
            try
            {
                return hrContext.Rooms.ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw new Exception("Error occurred while retrieving rooms.", ex);
            }
        }

        public Room CreateRoom(Room room)
        {
            try
            {
                var existingHotel = hrContext.Hotels.Find(room.Hotel_Id);
                if (existingHotel == null)
                {
                    throw new Exception("Hotel not found.");
                }

                room.Hotels = existingHotel;
                hrContext.Rooms.Add(room);
                hrContext.SaveChanges();

                return room;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw new Exception("Error occurred while creating room.", ex);
            }
        }

        public Room UpdateRoom(int id, Room room)
        {
            try
            {
                var existingRoom = hrContext.Rooms.FirstOrDefault(x => x.Room_Id == id);
                if (existingRoom != null)
                {
                    existingRoom.Room_Number = room.Room_Number;
                    existingRoom.Room_Type = room.Room_Type;
                    existingRoom.Room_Capacity = room.Room_Capacity;
                    existingRoom.Room_Availability = room.Room_Availability;

                    hrContext.SaveChanges();
                }
                return existingRoom;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw new Exception("Error occurred while updating room.", ex);
            }
        }

        public void DeleteRoom(int id)
        {
            try
            {
                Room del = hrContext.Rooms.FirstOrDefault(x => x.Room_Id == id);
                if (del != null)
                {
                    hrContext.Rooms.Remove(del);
                    hrContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                throw new Exception("Error occurred while deleting room.", ex);
            }
        }


    }
}
