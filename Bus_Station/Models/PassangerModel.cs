using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Station.Models
{
    public class PassangerModel
    {
        public string FIO { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
    }
}
