using BlazorCrud.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrud.Server.DataAccess
{
    public class EmployeeDataAccessLayer
    {
        EmployeeContext db = new EmployeeContext();

        //To get all employee details
        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                return db.tblEmployee.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record
        public void AddEmployee(Employee employee)
        {
            try
            {
                db.tblEmployee.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Update the records of a particluar employee
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get the details of a particular employee  
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee employee = db.tblEmployee.Find(id);
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Delete the record of a particular employee
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee employee = db.tblEmployee.Find(id);
                db.tblEmployee.Remove(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
