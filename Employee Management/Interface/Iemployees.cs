using EmployeeModel;

namespace Employee_Management.Interface
{
    public interface Iemployees
    {
        EmployeeDetails Add(EmployeeDetails job);
        List<EmployeeDetails> Get();

        EmployeeDetails Getemployee(int Id);
    }
}
