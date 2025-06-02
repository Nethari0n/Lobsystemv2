using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class ScanningDTO
    {

        public int ScanningID { get; set; }

        public int ChipID { get; set; }

        public int PostID { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
