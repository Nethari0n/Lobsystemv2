using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Domain.Model
{
    public class Event
    {
        [Required]
        public int EventID { get; set; }

        [MaxLength(200), Required]
        public string EventName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [MaxLength(2500), Required]
        public string Description { get; set; }

        [Required]
        public int Chips { get; set; }

        [Required]
        public int CooldownTimer { get; set; }

        [Required]
        public int TypesID { get; set; }

        public string Username { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Types Type { get; set; }

        public List<Post> Posts { get; set; }

        public Event()
        {
            IsDeleted = false;
        }
    }
}
