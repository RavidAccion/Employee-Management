using Employee_Management.data;
using Employee_Management.Interface;

namespace Employee_Management.Repository
{
    public class EmployeeService
    {
        private readonly DataBase _dbContext;
        public EmployeeService(DataBase dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly Iemployees _empData;
      

    }
}
