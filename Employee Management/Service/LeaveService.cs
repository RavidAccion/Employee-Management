using Employee_Management.data;
using Employee_Management.Interface;
using Employee_Management.models;

namespace Employee_Management.Service
{
    public class LeaveService : Ileave
    {
        private readonly db _dbContext;
        public LeaveService(db dbContext)
        {
            _dbContext = dbContext;
        }
        public leavesModel Add(leavesModel data)
        {
            _dbContext.Leave.Add(data);
            _dbContext.SaveChanges();

            return data;
        }
     

        public employee_leave_detaisl applyleave(employee_leave_detaisl data)
        {
            _dbContext.employee_leave_detaisl.Add(data);
            _dbContext.SaveChanges();

            return data;
        }

        public List<leavesModel> Getleavelist()
        {
           return  _dbContext.Leave.ToList();
        }

        public List<employee_leave_detaisl> GetleaveDatas()
        {
            return _dbContext.employee_leave_detaisl.ToList();
        }

        
        public leavesModel GetLeave(int Id)
        {
            var leave = _dbContext.Leave.Find(Id);

            return leave;
        }

        public employee_leave_detaisl GetLeavebyid(int emp_id)
        {
            var leave = _dbContext.employee_leave_detaisl.Find(emp_id);

            return leave;


        }

        public employee_details Getbyid(int emp_id)
        {
            var data = _dbContext.employee_details.Find(emp_id);

            return data;


        }
    }
}
