using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Sheduling
    {
        public int ID { get; set; }

        public bool Deleted { get; set; }

        public Termin Termin { get; set; }
        public User Patient { get; set; }

    }
}