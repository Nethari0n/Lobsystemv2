using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.Models
{
    public class ChipGroup
    {
        [Required]
        public int ChipGroupID { get; set; }

        [Required]
        public int ChipID { get; set; }

        public int GroupID { get; set; }
        [Required]
        public int EventID { get; set; }

        public int GroupNumber { get; set; }

        public Chip Chip { get; set; }
        public Group Group { get; set; }
    }
}
