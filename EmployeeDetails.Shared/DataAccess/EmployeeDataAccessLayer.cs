using EmployeeDetails.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeDetails.Shared.DataAccess
{
  public class EmployeeDataAccessLayer
  {
    EmployeeContext employeeContext = new EmployeeContext();

    public List<Employee> GetEmployees()
    {
      try
      {
        return employeeContext.Employee.ToList();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public List<Cities> GetCities()
    {
      try
      {
        return employeeContext.Cities.ToList();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void AddEmployee(Employee employee)
    {
      try
      {
        employeeContext.Employee.Add(employee);
        employeeContext.SaveChanges();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void UpdateEmployee(Employee employee)
    {
      try
      {
        employeeContext.Entry(employee).State = EntityState.Modified;
        employeeContext.SaveChanges();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public Employee GetEmployee(int id)
    {
      try
      {
        var employee = employeeContext.Employee.Find(id);
        employeeContext.Entry(employee).State = EntityState.Detached;
        return employee;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void DeleteEmployee(int id)
    {
      try
      {
        Employee employee = employeeContext.Employee.Find(id);
        employeeContext.Employee.Remove(employee);
        employeeContext.SaveChanges();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
