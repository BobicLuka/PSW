using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecepieService.Model
{
    public class Singlton
    {
        private static Singlton instance;
        private List<Recepie> recepies;
        public Singlton()
        {
            recepies = new List<Recepie>();
        }

        public List<Recepie> Recepies { get; }

        public static Singlton Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Singlton();
                }

                return instance;
            }
        }
    }
}
