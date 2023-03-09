using Microsoft.EntityFrameworkCore;
using System;
using Employee_Management;
using Employee_Management.models;

namespace Employee_Management.data
{
    public class db:DbContext

    {
        public db(DbContextOptions<db> options) : base(options)
        {

        }
        public DbSet<Job_Details> Job_Details { get; set; }
        public DbSet<employee_details> employee_details { get; set; }
        public DbSet<leavesModel> Leave { get; set; }
        public DbSet<employee_leave_detaisl> employee_leave_detaisl { get; set; }

    }

 
}
