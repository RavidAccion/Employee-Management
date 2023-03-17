using Microsoft.EntityFrameworkCore;
using System;
using Employee_Management;
using EmployeeModel;

namespace Employee_Management.data
{
    public class DataBase:DbContext

    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {

        }
        public DbSet<JobDetails> Job_Details { get; set; }
        public DbSet<EmployeeDetails> employee_details { get; set; }
        public DbSet<LeavesModel> Leave { get; set; }
        public DbSet<EmployeeLeaveDetails> employee_leave_detaisl { get; set; }
        public DbSet<LeaveResultset> leaveResultset { get; set; }

    }

 
}
