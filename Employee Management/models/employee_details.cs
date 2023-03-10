using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management.models
{
    public class employee_details
    {
        [Key]
        public int emp_Id { get; set; }

        [ForeignKey("Job_Details")]
        public int job_Id { get; set; }
        [Required]
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public int total_casual_leaves { get; set; }
        public int total_wellness_leaves { get; set; }
        public string e_mail { get; set; }
        public Int64 mobile { get; set; }
    }
}
