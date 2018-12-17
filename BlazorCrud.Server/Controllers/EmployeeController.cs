using BlazorCrud.Server.DataAccess;
using BlazorCrud.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlazorCrud.Server.Controllers
{
  [Route("api/[controller]/[action]")]
  public class EmployeeController : Controller
  {
    EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

    [HttpGet]
    public IEnumerable<Employee> Index()
    {
      return objemployee.GetAllEmployee();
    }

    [HttpPost]
    public void Create([FromBody] Employee employee)
    {
      if (ModelState.IsValid)
      {
        objemployee.AddEmployee(employee);
      }
    }

    [HttpGet]
    [Route("{id}")]
    public Employee Details(int id)
    {
      return objemployee.GetEmployeeData(id);
    }

    [HttpPut]
    public void Edit([FromBody] Employee employee)
    {
      if (ModelState.IsValid)
      {
        objemployee.UpdateEmployee(employee);
      }
    }

    [HttpDelete]
    [Route("{id}")]
    public void Delete(int id)
    {
      objemployee.DeleteEmployee(id);
    }
  }
}
