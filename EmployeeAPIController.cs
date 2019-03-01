using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("Api/Employee")]
    public class EmployeeAPIController : ApiController
    {
        EmpEntities empEntity = new EmpEntities();

        [HttpGet]
        [Route("AllEmployees")]
        public IQueryable<Employee> GetEmployees()
        {
            try
            {
                return empEntity.Employees;
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetEmployeeById/{employeeId}")]
        public IHttpActionResult GetEmployeeById(string employeeId)
        {
            Employee objEmp = new Employee();
            int ID = Convert.ToInt32(employeeId); 

            try
            {
                objEmp = empEntity.Employees.Find(ID);
                if(objEmp == null)
                {
                    return NotFound();
                }
            }
            catch(Exception)
            {
                throw;
            }

            return Ok(objEmp);
        }

        [HttpPost]
        [Route("InsertEmployees")]
        public IHttpActionResult PostEmployee(Employee data)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                empEntity.Employees.Add(data);
                empEntity.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }

            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateEmployees")]
        public IHttpActionResult PutEmployee(Employee data)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Employee objEmp = new Employee();
                objEmp = empEntity.Employees.Find(data.EmployeeID);
                if(objEmp != null)
                {
                    objEmp.EmployeeName = data.EmployeeName;
                    objEmp.Address = data.Address;
                    objEmp.EmailId = data.EmailId;
                    objEmp.Gender = data.Gender;
                    objEmp.DateOfBirth = data.DateOfBirth;
                    objEmp.PinCode = data.PinCode;
                }

                int i = this.empEntity.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }

            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(string id)
        {
            int empId = Convert.ToInt32(id);
            Employee emp = empEntity.Employees.Find(empId);
            if(emp == null)
            {
                return NotFound();
            }
            empEntity.Employees.Remove(emp);
            empEntity.SaveChanges();

            return Ok(emp);
        }
    }
}
