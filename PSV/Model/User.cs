using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class User
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Type  { get; set; }

        public string Speciality { get; set; }
        




    }
}
