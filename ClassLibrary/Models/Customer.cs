using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        public string? Customer_Name { get; set; } = string.Empty;
        public string? Customer_Email { get; set; }
        public string? Customer_Password { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
