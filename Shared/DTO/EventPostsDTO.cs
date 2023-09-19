using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class EventPostsDTO
    {
        public CreateEventDTO CreateEvent { get; set; }

        public List<PostDTO> PostList { get; set; }
    }
}
