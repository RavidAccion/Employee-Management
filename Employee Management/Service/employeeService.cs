using Employee_Management.data;
using Employee_Management.Interface;
using Employee_Management.models;

namespace Employee_Management.Service
{
    public class employeeService : Iemployees
    {
        private readonly db _dbContext;
        public employeeService(db dbContext)
        {
            _dbContext = dbContext;
        }

        public employee_details Add(employee_details emp)
        {
            _dbContext.employee_details.Add(emp);
            _dbContext.SaveChanges();

            return emp;
        }

        public List<employee_details> Get()
        {
            return _dbContext.employee_details.ToList();
        }
    }
}
