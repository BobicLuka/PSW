using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Sheduling> Shedulings { get; set; }
        public DbSet<Termin> Termins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) { 
        
            if(optionBuilder.IsConfigured)
            {
                return;
            }

            optionBuilder.UseSqlServer("Server=DESKTOP-OU1TIKJ;Database=psv;Trusted_Connection=True;");
        }
    }
}
