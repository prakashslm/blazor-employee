using EmployeeDetails.Shared.DataAccess;
using EmployeeDetails.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.App.Services
{
  public class EmployeeService
  {
    EmployeeDataAccessLayer employeeDataAccessLayer = new EmployeeDataAccessLayer();
    public Task<List<Employee>> GetEmployees()
    {
      return Task.FromResult(employeeDataAccessLayer.GetEmployees());
    }
    public Task<List<Cities>> GetCities()
    {
      return Task.FromResult(employeeDataAccessLayer.GetCities());
    }
    public void AddEmployee(Employee employee)
    {
      employeeDataAccessLayer.AddEmployee(employee);
    }
    public void UpdateEmployee(Employee employee)
    {
      employeeDataAccessLayer.UpdateEmployee(employee);
    }
    public Task<Employee> GetEmployee(int id)
    {
      return Task.FromResult(employeeDataAccessLayer.GetEmployee(id));
    }
    public void DeleteEmployee(int id)
    {
      employeeDataAccessLayer.DeleteEmployee(id);
    }
  }
}
