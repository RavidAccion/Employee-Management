﻿using Employee_Management.Interface;
using EmployeeModel;
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
        public IActionResult Add(LeavesModel data)

        {
            _leavData.Add(data);
            return Created("/" + data, data);
        }

        [HttpPost]
        [Route("applyleave")]
        public IActionResult applyleave(EmployeeLeaveDetails data)
           
        {
            var details = data;
       
            var result =    _leavData.Getbyid(data.emp_id, details);

            if(result.error != null)
            {
                return BadRequest(result);
            }
            else
            {
                _leavData.Editleaves(data);
                _leavData.applyleave(data);

                return Ok(data);
            }

          

        }

        [HttpGet]
        [Route("Getleavelist")]
        public IActionResult Getleavelist()
        {
            var data = _leavData.Getleavelist();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetAppliedLeavedatas")]
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
