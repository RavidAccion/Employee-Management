using Employee_Management.data;
using Employee_Management.Interface;
using Employee_Management.models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Service
{
    public class jobdetailService : Ijobdetails
    {
        private readonly db _dbContext;
        public jobdetailService(db dbContext)
        {
            _dbContext = dbContext;
        }
        public Job_Details Add(Job_Details job)
        {
            _dbContext.Job_Details.Add(job);
            _dbContext.SaveChanges();

            return job;
        }

        List<Job_Details> Ijobdetails.Get()
        {
            return _dbContext.Job_Details.ToList();
        }

     
    }
}
