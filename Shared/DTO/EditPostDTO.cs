using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class EditPostDTO : PostDTO
    {
        public int PostId { get; set; }
        public int EventId { get; set; }
    }
}
