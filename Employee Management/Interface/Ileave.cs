using EmployeeModel;

namespace Employee_Management.Interface
{
    public interface Ileave
    {
        LeavesModel Add(LeavesModel data);
        List<LeavesModel> Getleavelist();

        List<EmployeeLeaveDetails> GetleaveDatas();

        EmployeeLeaveDetails applyleave(EmployeeLeaveDetails data);

        LeavesModel GetLeave(int Id);
        EmployeeLeaveDetails GetLeavebyid(int emp_id);

        LeaveResultset Getbyid(int data, EmployeeLeaveDetails details);

        EmployeeDetails Editleaves(EmployeeLeaveDetails data);
      
    }
}
