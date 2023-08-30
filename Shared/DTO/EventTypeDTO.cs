using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class EventTypeDTO
    {
        [Required]
        public int EventID { get; set; }

        [MaxLength(200), Required]
        public string EventName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }


        [MaxLength(2500), Required]
        public string Description { get; set; }

        [Required]
        public int CooldownTimer { get; set; }

        [Required]
        public int TypesID { get; set; }

        [MaxLength(30), Required]
        public string TypeName { get; set; }
        public string Username { get; set; }
    }
}
