using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Domain.Model
{
    public class Chip
    {
        [Required]
        public int ChipID { get; set; }

        [Required]
        public string UID { get; set; }

        [MaxLength(30)]
        public string LaanerID { get; set;}
        
        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? ChangeDate { get; set; }

        [Required]
        public bool Aktive { get; set; }


        public List<Registration> Registration { get; set; }

        public List<ChipGroup> ChipGroup { get; set; }

        public List<Scanning> Scanning { get; set; }



        public Chip()
        {
            Aktive = true;
        }
    }
}
