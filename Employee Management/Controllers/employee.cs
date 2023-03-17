using Employee_Management.Interface;
using EmployeeModel;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employee : Controller
    {
        private readonly Iemployees _empData;

        public employee(Iemployees empData)
        {
            _empData = empData;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Add(EmployeeDetails emp)

        {
            _empData.Add(emp);
            return Created("/" + emp, emp);
        }



        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = _empData.Get();
            return Ok(data);
        }

        [HttpGet]
        [Route("getemployeeID/{emp_id}")]
        public IActionResult GetLeavedatabyid(int emp_id)
        {
            var DatabyID = _empData.Getemployee(emp_id);
            if (DatabyID != null)
            {
                return Ok(DatabyID);
            }

            return NotFound($"Employeewith Id: {emp_id} was not found");
        }

    }
}
