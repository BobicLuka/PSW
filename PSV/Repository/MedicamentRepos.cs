using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class MedicamentRepos
    {
        ProjectContext context;

        public MedicamentRepos(ProjectContext context)

        {
            this.context = context;
        }

        public Medicament Get(int id)
        {

            return this.context.Set<Medicament>().Find(id);
        }

        public List<Medicament> GetAll()
        {

            return context.Set<Medicament>().ToList();
        }

        public void Add(Medicament medicament)
        {
            context.Set<Medicament>().Add(medicament);
        }


    }
}
