﻿namespace LinkedIn.Data
{
    using LinkedIn.Data.Repositories;
    using LinkedIn.Models;
    using System;
    using System.Collections.Generic;

    public class LinkedInData : ILinkedInData
    {
        private ILinkedInContext context;
        private IDictionary<Type, object> repositories;

        public LinkedInData(ILinkedInContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Certification> Certifications
        {
            get { return this.GetRepository<Certification>(); }
        }

        public IRepository<Discussion> Discussions
        {
            get { return this.GetRepository<Discussion>(); }
        }

        public IRepository<Experience> Experiences
        {
            get { return this.GetRepository<Experience>(); }
        }

        public IRepository<Group> Groups
        {
            get { return this.GetRepository<Group>(); }
        }

        public IRepository<Project> Projects
        {
            get { return this.GetRepository<Project>(); }
        }

        public IRepository<Skill> Skills
        {
            get { return this.GetRepository<Skill>(); }
        }

        public IRepository<Endorcement> Endorcements
        {
            get { return this.GetRepository<Endorcement>(); }
        }

        public IRepository<AdministrationLog> AdministrationLogs
        {
            get { return this.GetRepository<AdministrationLog>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                //                if (type.IsAssignableFrom(typeof(Game)))
                //                {
                //                    typeOfRepository = typeof(GamesRepository);
                //                }

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
