using Employee_Management.models;

namespace Employee_Management.Interface
{
    public interface Iemployees
    {
        employee_details Add(employee_details job);
        List<employee_details> Get();
    }
}
