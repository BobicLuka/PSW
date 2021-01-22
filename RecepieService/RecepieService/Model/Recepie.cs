using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepieService.Model
{
    public class Recepie
    {
        public int Id { get; set; }
        public Medicine Medicine { get;set; }

        public Patient Patient { get; set; }
    }
}
