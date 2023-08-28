using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Domain.Model
{
    public class Post
    {
        [Required]
        public int PostID { get; set; }

        [Required]
        public int EventID { get; set; }

        [Required]
        public int Multiplyer { get; set; }

        [Required, MaxLength(5)]
        public int Distance { get; set; }

        [Required]
        public int PostNum { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Event Event { get; set; }

        public List<Scanning> Scannings { get; set; }

        public Post()
        {
            IsDeleted = false;
        }
    }
}
