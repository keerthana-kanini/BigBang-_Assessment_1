using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string? StaffName { get; set; }

        public bool Manage_Room_Availability { get; set; }
        public int Hotel_Id { get; set; }
        public Hotel Hotels { get; set; }
    }
}
