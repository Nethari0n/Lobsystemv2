using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Domain.Model
{
    public class Group
    {
        [Required]
        public int GroupID { get; set; }

        [MaxLength(30),Required]
        public string GroupName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public List<ChipGroup> ChipGroup { get; set; }

        public Group()
        {
            IsDeleted = false;
        }
    }
}
