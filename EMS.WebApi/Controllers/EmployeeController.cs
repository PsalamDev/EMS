﻿using EMS.Application.DTOs.Employee;
using EMS.Application.Interface.Repository;
using EMS.Application.Interface.Service;
using EMS.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = _employeeService;
        }

        


        #region Crud Employee
        
        
        [HttpPost("employee/create")]
        public async Task<IActionResult> Create(EmployeeDto request)
        {
            try
            {
                var response = await _employeeService.Create(request);
                return Ok(response);
            }
            catch
            {
                return Ok(new
                {
                    status = "error",
                    message = "Something happened. Please try again later."
                });
            }
           
        }

        [HttpGet("employee")]
     
        public async Task<IActionResult> ViewEmployee()
        {
            var instances = await _employeeService.LoadAllEmployee();
            return Ok(instances);
        }

       

        [HttpGet("employee/{id}")]
        public async Task<IActionResult> ViewEmployeeDetail([FromRoute] Guid id)
        {
            var instance = await _employeeService.LoadEmployeeDetail(id);

            return instance == null
                       ? (IActionResult)NotFound()
                       : Ok(instance);
        }

        [HttpPut("employee/{id}/edit")]
       
        public async Task<IActionResult> EditEmployee([FromRoute] Guid id, [FromBody] EmployeeDto  request)
        {
            try
            {
                var response = await _employeeService.Update(id, request);
                return Ok(response);
            }
            catch
            {
                return Ok(new
                {
                    status = "error",
                    message = "Something happened. Please try again later."
                });
            }
        }

        [HttpDelete("employee/{id}/delete")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                var response = await _employeeService.Delete(id);
                return Ok(response);
            }
            catch
            {
                return Ok(new
                {
                    status = "error",
                    message = "Something happened. Please try again later."
                });
            }
        }
    }
        #endregion   
}

