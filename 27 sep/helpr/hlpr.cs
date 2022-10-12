using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bussinesslogic;
using dataaccess;
namespace helper
{
    public class EmployeeHelper
    {

        EmployeeDAL dal = null;
       
       
            dal = new EmployeeDAL();
       

        public int RowCountEmployees()
        {
            return dal.RowCountEmployees();

        }
        public bool AddNewEmployee(Employee_BAL employee)
        {
            return dal.InsertEmployee(employee);
        }
        public Employee_BAL LocateEmployee(int empid)
        {
            return dal.FindEmployee(empid);
        }

        public List<Employee_BAL> EmployeeList()
        {
            return dal.ShowAllEmps();
        }

        public bool RemoveEmployeeData(int empid)
        {
            return dal.DeleteEmployee(empid);
        }



        public bool EditEmployeeData(int empid, Employee_BAL employee)
        {
            return dal.UpdateEmployee(empid, employee);
        }


    }
}
