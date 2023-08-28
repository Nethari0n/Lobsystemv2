using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Domain.Model
{
    public class Types
    {
        [Required]
        public int TypesID { get; set; }
        [MaxLength(30), Required]
        public string TypeName { get; set; }
        [Required]
        public int Multiplyer { get; set; }

        [Required]
        public bool MultipleRounds { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public List<Event> Event { get; set; }

        public Types()
        {
            IsDeleted = false;
        }
    }
}
