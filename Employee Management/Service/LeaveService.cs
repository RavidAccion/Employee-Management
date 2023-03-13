using Employee_Management.data;
using Employee_Management.Interface;
using Employee_Management.models;
using System.Reflection.Metadata.Ecma335;

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

        public employee_leave_detaisl applyleave(employee_leave_detaisl data)
        {


            _dbContext.employee_leave_detaisl.Add(data);
            _dbContext.SaveChanges();

            return data;
        }

        public leaveResultset Getbyid(int emp_id, employee_leave_detaisl details)

        {
            var result = new leaveResultset();
            var data = _dbContext.employee_details.Find(emp_id );

          

            if (details.leave_type == 1 && details.no_of_days > 2)
            {
               if(data.total_wellness_leaves == 0)
                {
                    var error = "You Dont have Any Leaves";
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

         employee_details Ileave.Editleaves(employee_leave_detaisl data)
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
