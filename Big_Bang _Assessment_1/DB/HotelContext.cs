using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;



namespace Big_Bang__Assessment_1.DB
{
    public class HotelContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }



        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }



    }

}

