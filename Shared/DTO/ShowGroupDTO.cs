using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class ShowGroupDTO : CreateGroupDTO
    {
        public int GroupId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
