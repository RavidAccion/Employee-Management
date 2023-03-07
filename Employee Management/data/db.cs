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

    }

 
}
