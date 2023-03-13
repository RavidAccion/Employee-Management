using System.ComponentModel.DataAnnotations;

namespace Employee_Management.models
{
    public class leaveResultset
    {
        public bool status { get; set; }
        public employee_details data { get; set; }
        [Key]
        public string error { get; set; }
            
    }
}
