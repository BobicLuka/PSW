﻿using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class UnitOfWork : IDisposable

    {
        private readonly ProjectContext context;

        public UnitOfWork(ProjectContext context)

        {
            this.context = context;
            Users = new UserRepos(this.context);
            Schedulings = new SchedulingRepos(this.context);
            Termins = new TerminRepos(this.context);
            Medicaments = new MedicamentRepos(this.context);
            Feedbacks = new FeedbackRepos(this.context);
        }

        public UserRepos Users { get; private set; }
        public SchedulingRepos Schedulings { get; private set; }
        public TerminRepos Termins { get; private set; }
        public MedicamentRepos Medicaments { get; private set; }
        public FeedbackRepos Feedbacks { get; private set; }


        public ProjectContext Context
        { 
            get { return context; }
        
        }

        public object Shedulings { get; internal set; }

        public int Complete()
        {
            return context.SaveChanges();
        }


        public void Dispose()

        {
            context.Dispose();
        }




    }
}
