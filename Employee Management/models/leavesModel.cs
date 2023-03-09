using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Management.models
{
    public class leavesModel
    {



        [Key]
        public int id { get; set; }


        public string leave_types { get; set; }
       
    }

    
}
