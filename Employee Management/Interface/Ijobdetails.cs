using Employee_Management.models;

namespace Employee_Management.Interface
{
    public interface Ijobdetails
    {
        Job_Details Add(Job_Details job);
        List<Job_Details> Get();
    }
}
