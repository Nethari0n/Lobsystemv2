using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.Models
{
    public class Scanning
    {
        [Required]
        public int ScanningID { get; set; }
        [Required]
        public int ChipID { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public Chip Chip { get; set; }
        public Post Post { get; set; }
    }
}
