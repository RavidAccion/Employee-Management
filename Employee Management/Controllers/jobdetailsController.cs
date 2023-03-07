using Employee_Management.Interface;
using Employee_Management.models;
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
        [Route("createProduct")]
        public IActionResult Add(Job_Details job)

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
