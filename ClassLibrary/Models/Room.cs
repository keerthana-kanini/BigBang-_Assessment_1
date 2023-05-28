using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Room
    {
        [Key]
        public int Room_Id { get; set; }
        public string ? Room_Name { get; set; }

        public string ? Room_Availability { get; set; }
        public int Hotel_Id { get; set; }

        public Hotel Hotels { get; set; }

    }
}
