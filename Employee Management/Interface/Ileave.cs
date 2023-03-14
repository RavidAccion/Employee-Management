using Employee_Management.models;

namespace Employee_Management.Interface
{
    public interface Ileave
    {
        leavesModel Add(leavesModel data);
        List<leavesModel> Getleavelist();

        List<employee_leave_detaisl> GetleaveDatas();

        employee_leave_detaisl applyleave(employee_leave_detaisl data);
    
        leavesModel GetLeave(int Id);
        employee_leave_detaisl GetLeavebyid(int emp_id);

        leaveResultset Getbyid(int data, employee_leave_detaisl details);

        employee_details Editleaves(employee_leave_detaisl data);
      
    }
}
