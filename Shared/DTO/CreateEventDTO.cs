using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class CreateEventDTO
    {
        public string EventName { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }


        public string Description { get; set; }

        public int CooldownTimer { get; set; }

        public int TypesID { get; set; }

        public string Username { get; set; }
    }
}
