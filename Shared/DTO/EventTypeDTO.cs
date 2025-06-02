using Lobsystem.Shared.Models;
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
        
        public int EventID { get; set; }

        
        public string EventName { get; set; }

        
        public DateTime StartDate { get; set; }

        
        public DateTime EndDate { get; set; }


        public string Description { get; set; }

        public int CooldownTimer { get; set; }

        public int TypesID { get; set; }

        public string TypeName { get; set; }
        public string Username { get; set; }

        public List<PostDTO> Posts { get; set; }
    }
}
