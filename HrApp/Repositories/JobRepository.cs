﻿using System.Collections.Generic;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    using System;

    public class JobRepository : DbExecuteProvider, IRepository<Job>
    {
        public JobRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public Job Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@JobId", id } };

            return CustomExecuteReader<Job>("sp_GetJobById", parameters).FirstOrDefault();
        }

        public IEnumerable<Job> GetAll()
        {
            return CustomExecuteReader<Job>("sp_GetJobs").ToList();
        }

        public IEnumerable<Job> GetAllWhere(Job job, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", job.PersonId},
                {"@JobName", job.JobName}
            };

            return CustomExecuteReader<Job>("sp_GetJobsWhere", parameters).ToList();
        }

        public IEnumerable<Job> Get(Func<Job, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Job job)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", job.PersonId},
                {"@JobName", job.JobName}
            };

            CustomExecuteNonQuery("sp_AddJob", parameters);
        }

        public void Edit(Job job)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@JobId", job.JobId},
                {"@JobName", job.JobName}
            };

            CustomExecuteNonQuery("sp_EditJob", parameters);
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@JobId", id}
            };

            CustomExecuteNonQuery("sp_DeleteJob", parameters);
        }

    }
}