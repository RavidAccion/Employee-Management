using EmployeeModel;

namespace Employee_Management.Interface
{
    public interface Ijobdetails
    {
        JobDetails Add(JobDetails job);
        List<JobDetails> Get();
    }
}
