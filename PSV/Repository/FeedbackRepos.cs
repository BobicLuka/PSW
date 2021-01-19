﻿using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Repository
{
    public class FeedbackRepos
    {
        ProjectContext context;

        public FeedbackRepos(ProjectContext context)

        {
            this.context = context;
        }

        public Feedback Get(int id) {

            return this.context.Set<Feedback>().Find(id);
        }

        public List<Feedback> GetAll() {

            return context.Set<Feedback>().ToList();
        }

        internal void Add(Feedback feedback)
        {
            throw new NotImplementedException();
        }
    }
}
