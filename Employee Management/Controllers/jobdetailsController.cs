using Employee_Management.Interface;
using EmployeeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class jobdetailsController : Controller
    {
        private readonly Ijobdetails _jobData;

        public jobdetailsController(Ijobdetails jobData)
        {
            _jobData = jobData;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Add(JobDetails job)

        {
            _jobData.Add(job);
            return Created("/" + job, job);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = _jobData.Get();
            return Ok(data);
        }
    }
}
