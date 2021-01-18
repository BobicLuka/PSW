using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class UserRepos
    {
        
            ProjectContext context;

        public UserRepos(ProjectContext context)

        {
            this.context = context;
        }


        public User Get(int id)
        {
            return this.context.Set<User>().Find(id);
        }


        public List<User> GetAll()
        {

            return context.Set<User>().ToList();
        }


    }

        

    }

