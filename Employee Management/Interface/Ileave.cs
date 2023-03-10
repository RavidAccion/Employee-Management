using Employee_Management.models;

namespace Employee_Management.Interface
{
    public interface Ileave
    {
        leavesModel Add(leavesModel data);
        List<leavesModel> Getleavelist();

        List<employee_leave_detaisl> GetleaveDatas();

        employee_leave_detaisl applyleave(employee_leave_detaisl data);
        /*
                leavesModel EditLeave(applyleave data);*/
        leavesModel GetLeave(int Id);
        employee_leave_detaisl GetLeavebyid(int emp_id);

        employee_details Getbyid(int emp_id);

        employee_details Editleaves(employee_details data);
    }
}
