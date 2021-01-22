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

        public User GetUserWithEmailAndPassword(string email, string password) 
        {
            return context.Set<User>().Where(x => x.Email == email && x.Password == password ).FirstOrDefault();
        }

        public User GetUserWithEmail(string email)
        {
            return context.Set<User>().Where(x => x.Email == email).FirstOrDefault();
        }


        public List<User> GetAll()
        {

            return context.Set<User>().Where(x => x.Type == "DOCTOR").ToList();
        }

        public List<User> GetAllDoctors()
        {

            return context.Set<User>().ToList();
        }

        public void Add(User user) 
        {
            context.Set<User>().Add(user);
        }
    }

        

    }

