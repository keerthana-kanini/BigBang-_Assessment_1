using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Hotel
    {
        [Key]
        public int Hotel_Id { get; set; }

        public string? Hotel_Name { get; set; }

        public string ?Hotel_Location { get; set; }
        public int? Hotel_Price { get; set; }
        public int Room_Availability { get; set; }

        public string ? Hotel_Amenities { get; set; }

        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Staff>? Staff { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
