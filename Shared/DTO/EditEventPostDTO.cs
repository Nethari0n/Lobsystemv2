using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class EditEventPostDTO
    {
        public EditEventDTO EditEventDTO { get; set; }

        public List<EditPostDTO> EditPostDTOs { get; set; }
    }
}
