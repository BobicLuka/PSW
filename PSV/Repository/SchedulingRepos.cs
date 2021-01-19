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
      


        public Scheduling Get(int id)
            {
                return this.context.Set<Scheduling>().Find(id);
            }



        public List<Scheduling> GetAll()
        {

            return context.Set<Scheduling>().ToList();
        }

    }
}
