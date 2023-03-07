using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management.models
{
    public class Job_Details
    {

        [Key]
        public int job_Id { get; set; }

        public string job_Dept { get; set; }
        [Required]
        public string Job_name { get; set; }
        public string Job_Description { get; set; }

       
  y
       
}
}
