using Employee_Management.Interface;
using Employee_Management.models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class leaveController : Controller
    {

        private readonly Ileave _leavData;

        public leaveController(Ileave leavData)
        {
            _leavData = leavData;
        }

        [HttpPost]
        [Route("createLeave")]
        public IActionResult Add(leavesModel data)

        {
            _leavData.Add(data);
            return Created("/" + data, data);
        }

        [HttpPost]
        [Route("applyleave")]
        public IActionResult applyleave(employee_leave_detaisl data)
            
        {
           if (data.leave_type == 1 && data.no_of_days > 2)
            {

             var error= "You Can't Apply For Wellness Leave More Than 2 days";
                return BadRequest(error);

            }
            else {
                var DatabyID = _leavData.Getbyid(data.emp_id);
                if (data.leave_type == 1)
                {
                    data.rem_wellness = DatabyID.total_wellness_leaves - data.no_of_days;
                    DatabyID.total_wellness_leaves = data.rem_casual;
                    _leavData.Editleaves(DatabyID);
                }
                else
                {
                    data.rem_wellness = DatabyID.total_wellness_leaves;
                }
                if (data.leave_type == 2)
                {
                    data.rem_casual = DatabyID.total_casual_leaves - data.no_of_days;
                    DatabyID.total_casual_leaves = data.rem_casual;
                    _leavData.Editleaves(DatabyID);
                }
                else
                {
                    data.rem_casual = DatabyID.total_casual_leaves;
                }
             
            }

            _leavData.applyleave(data);
            return Created("/" + data, data);

        }

        [HttpGet]
        [Route("Getleavelist")]
        public IActionResult Getleavelist()
        {
            var data = _leavData.Getleavelist();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetleaveData")]
        public IActionResult GetleaveDatas()
        {
            var data = _leavData.GetleaveDatas();
            return Ok(data);
        }

        [HttpGet]
        [Route("getdatabyID/{emp_id}")]
        public IActionResult GetLeavedatabyid(int emp_id)
        {
            var DatabyID = _leavData.GetLeavebyid(emp_id);
            if (DatabyID != null)
            {
                return Ok(DatabyID);
            }

            return NotFound($"Task with Id: {emp_id} was not found");
        }


    }
}
