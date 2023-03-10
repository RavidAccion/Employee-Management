using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management.models
{
    public class employee_leave_detaisl
    {
        [Key]
        [ForeignKey("employee_details")]
        public int emp_id { get; set; }
        public int leave_type { get; set; }
        public int rem_wellness { get; set; }
        public int rem_casual { get; set; }
        virtual public int no_of_days { get; set; }
        public string reason {  get; set; }
    }
}
