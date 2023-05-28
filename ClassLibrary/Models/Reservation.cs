using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Reservation
    {
        [Key]
        public int Reservation_Id { get; set; }
        public DateTime Check_in_date { get; set; }
        public DateTime Check_out_date { get; set; }

       

        public int Customer_Id { get; set; }
        public Customer Customers { get; set; }

        public int Hotel_Id { get; set; }
        public Hotel hotels { get; set; }
    }
}
