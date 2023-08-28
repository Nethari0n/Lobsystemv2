using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Domain.Model
{
    public class Registration
    {
        [Required]
        public int RegistrationID { get; set; }
        [Required]
        public int ChipID { get; set; }
        [Required]
        public int EventID { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public Event Event { get; set; }
        public Chip Chip { get; set; }
    }
}
