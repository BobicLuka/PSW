using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class SchedulingRepos
    {
        ProjectContext context;

        public SchedulingRepos(ProjectContext context) 
        {
            this.context = context;
        }
      


        public Sheduling Get(int id)
            {
                return this.context.Set<Sheduling>().Find(id);
            }



        public List<Sheduling> GetAll()
        {

            return context.Set<Sheduling>().ToList();
        }

    }
}
