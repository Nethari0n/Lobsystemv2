using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class ChipHandlingDTO
    {
        public int? ChipID { get; set; }

        [Required]
        public string UID { get; set; }

        [MaxLength(30)]
        public string LaanerID { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [AllowNull]
        public DateTime? ChangeDate { get; set; }

        [Required]
        public bool Aktive { get; set; }

        public ChipHandlingDTO()
        {
            Aktive = true;
            CreateDate = DateTime.Now;
        }
    }
}
