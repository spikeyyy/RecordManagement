using Microsoft.AspNetCore.Mvc;
using RecordManagement.Application.Contracts;
using RecordManagement.Domain.Entities;

namespace RecordManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployee employee;

    public EmployeeController(IEmployee employee)
    {
        this.employee = employee;
    }

    //get api/<EmployeeController>/
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await employee.GetAsync();
        return Ok(data);
    }

    //get the api/<EmployeeController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await employee.GetByIdAsync(id);
        return Ok(data);
    }

    //post the api/<EmployeeController>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Employee employeeDto)
    {
        var result = await employee.AddAsync(employeeDto);
        return Ok(result);
    }

    //put api/<EmployeeController>/5
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Employee employeeDto)
    {
        var result = await employee.UpdateAsync(employeeDto);
        return Ok(result);
    }

    //delete the api/<EmployeeController>/5
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await employee.DeleteAsync(id);
        return Ok(result);
    }
}