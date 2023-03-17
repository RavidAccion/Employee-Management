using Employee_Management.data;
using Employee_Management.Interface;
using EmployeeModel;
using System.Reflection.Metadata.Ecma335;

namespace Employee_Management.Service
{
    public class LeaveService : Ileave
    {
        private readonly DataBase _dbContext;
        public LeaveService(DataBase dbContext)
        {
            _dbContext = dbContext;
        }


        //method to add leave type in leave table
        public LeavesModel Add(LeavesModel data)
        {
            _dbContext.Leave.Add(data);
            _dbContext.SaveChanges();

            return data;
        }
     

      
        //method to get the list of leaves in leave table
        public List<LeavesModel> Getleavelist()
        {
           return  _dbContext.Leave.ToList();
        }


        //to get the list of datas in employee leave details table
        public List<EmployeeLeaveDetails> GetleaveDatas()
        {
            return _dbContext.employee_leave_detaisl.ToList();
        }

        
        //method to get leaves from leave table by id
        public LeavesModel GetLeave(int Id)
        {
            var leave = _dbContext.Leave.Find(Id);

            return leave;
        }


        //to get data from employee leave details by id
        public EmployeeLeaveDetails GetLeavebyid(int emp_id)
        {
            var leave = _dbContext.employee_leave_detaisl.Find(emp_id);

            return leave;


        }


        //method to create leave in employee leave details table
        public EmployeeLeaveDetails applyleave(EmployeeLeaveDetails data)
        {


            _dbContext.employee_leave_detaisl.Add(data);
            _dbContext.SaveChanges();

            return data;
        }


        //method to grt the data from employee id and performs logic with Api datas and table datas
        public LeaveResultset Getbyid(int emp_id, EmployeeLeaveDetails details)

        {
            var result = new LeaveResultset();
            var data = _dbContext.employee_details.Find(emp_id );
            if (details.leave_type == 1 && details.no_of_days > 2)
            {
               if(data.total_wellness_leaves == 0)
                {
                    var error = "You Dont have Any Casual Leaves";
                    result.error = error;
                    result.status = false;
                }
                else {
                    var error = "You Can't Apply For Wellness Leave More Than 2 days";
                    result.error = error;
                    result.status = false;
                }               
           }
            else
            {
                if (details.leave_type == 1)
                {
                    if(data.total_wellness_leaves != 0)
                    {
                        details.rem_wellness = data.total_wellness_leaves - details.no_of_days;
                        data.total_wellness_leaves = details.rem_casual;

                        result.error = null;
                        result.data = data;
                        result.status = true;
                    }
                    else {
                        var error = "You Dont have Any Wellness Leaves";
                        result.error = error;
                        result.status = false;
                    }
                }
                else
                {
                    details.rem_wellness = data.total_wellness_leaves;
                }
                if (details.leave_type == 2)
                {
                    if (data.total_casual_leaves != 0)
                    {
                        details.rem_casual = data.total_casual_leaves - details.no_of_days;
                        data.total_casual_leaves = details.rem_casual;


                        result.error = null;
                        result.data = data;
                        result.status = true;
                    }
                    else
                    {
                        var error = "You Dont have Any Casual Leaves";
                        result.error = error;
                        result.status = false;
                    }

                }
                else
                {
                    details.rem_casual = data.total_casual_leaves;
                }
             

            }

            return result;

        }

        //method to edit the leave counts in employee leave details table
         EmployeeDetails Ileave.Editleaves(EmployeeLeaveDetails data)
        {
            var existingdata = _dbContext.employee_details.Find(data.emp_id);
            if (existingdata != null)
            {
                existingdata.total_casual_leaves=data.rem_casual;
                
                existingdata.total_wellness_leaves = data.rem_wellness;
        
            }
            _dbContext.employee_details.Update(existingdata);
            _dbContext.Entry(existingdata)
                .Property(x => x.emp_Id).IsModified = false; // To Prevent Idenity column update issue
            _dbContext.SaveChanges();
            return existingdata;

        }
    }
}
