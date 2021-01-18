using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class TerminRepos
    {
        ProjectContext context;

        public TerminRepos(ProjectContext context)

        {
            this.context = context;
        }

        public Termin Get(int id)
        {
            return this.context.Set<Termin>().Find(id);
        }

        public List<Termin> GetAll()
        {

            return context.Set<Termin>().ToList();
        }
    }
}
