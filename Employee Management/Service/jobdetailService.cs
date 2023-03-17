using Employee_Management.data;
using Employee_Management.Interface;
using EmployeeModel;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Service
{
    public class jobdetailService : Ijobdetails
    {
        private readonly DataBase _dbContext;
        public jobdetailService(DataBase dbContext)
        {
            _dbContext = dbContext;
        }
        public JobDetails Add(JobDetails job)
        {
            _dbContext.Job_Details.Add(job);
            _dbContext.SaveChanges();

            return job;
        }

        List<JobDetails> Ijobdetails.Get()
        {
            return _dbContext.Job_Details.ToList();
        }

     
    }
}
