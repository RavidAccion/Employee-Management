using Employee_Management.Interface;
using Employee_Management.models;
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
        [Route("createProduct")]
        public IActionResult Add(employee_details emp)

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

    }
}
