using Employee_Management.data;
using Employee_Management.Interface;
using Employee_Management.Repository;
using EmployeeModel;
using Employee_Management.Repository;

namespace Employee_Management.Service
{
    public class employeeService : Iemployees
    {
        private readonly DataBase _dbContext;
        public employeeService(DataBase dbContext)
        {
            _dbContext = dbContext;
        }

        public EmployeeDetails Add(EmployeeDetails emp)
        {
            _dbContext.employee_details.Add(emp);
            _dbContext.SaveChanges();

            return emp;
        }

        public List<EmployeeDetails> Get()
        {
            return _dbContext.employee_details.ToList();
        }

        public EmployeeDetails Getemployee(int emp_id)
        {
            var leave = _dbContext.employee_details.Find(emp_id);

            return leave;


        }
    }
}
