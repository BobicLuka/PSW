using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Termin
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

        public DateTime Date { get; set; }
        public User Doctor { get; set; }
        public bool IsFree { get; set; }
    }
}
