using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bussinesslogic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace dataaccess
{
    public class EmployeeDAL
    {
        DataSet ds = null;
        SqlDataAdapter da = null;
        SqlConnection cn = null;
        public EmployeeDAL()
        {
            ds = new DataSet();//in memory cache called DataSet
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
        }

        private DataTable Connect()
        {
            da = new SqlDataAdapter("select * from employees", cn);

            //da takes the data from the database using a select query and will disconnect
            //from the database server once it fills/pushes the data to the DataSet
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "employees");//disconnect from our database server
                                     //Single dataset object can hold multiple tables inside it
                                     //To identify each table uniquely we can use a index or name.
                                     //index starts with 0, but better to work with name.
            DataTable dt_empdata = ds.Tables["employees"];
            return dt_empdata;
        }

        public int RowCountEmployees()
        {
            DataTable dt_empdata = Connect();
            int empcnt = dt_empdata.Rows.Count;
            return empcnt;



        }


        public bool UpdateEmployee(int empid, Employee_BAL employee)
        {
            DataTable dt_empdata = Connect();
            DataRow drow = ds.Tables["employees"].Rows.Find(empid);


            drow["FirstName"] = employee.FirstName;
            drow["LastName"] = employee.LastName;
            drow["Title"] = employee.Title;
            drow["BirthDate"] = employee.BirthDate;

            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["employees"]);//record added to the (original)database table
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;



        }
        public Employee_BAL FindEmployee(int empid)
        {
            DataTable dt_empdata = Connect();
            DataRow drow = ds.Tables["employees"].Rows.Find(empid);
            Employee_BAL emp = new Employee_BAL();
            emp.EmployeeID = Convert.ToInt32(drow["EmployeeID"]);
            emp.FirstName = drow["FirstName"].ToString();
            emp.LastName = drow["LastName"].ToString();
            emp.Title = drow["Title"].ToString();
            emp.BirthDate = Convert.ToDateTime(drow["BirthDate"]);
            return emp;



        }


        public List<Employee_BAL> ShowAllEmps()
        {
            DataTable dt_empdata = Connect();
            List<Employee_BAL> emplist = new List<Employee_BAL>();
            for (int i = 0; i < dt_empdata.Rows.Count; i++)
            {
                DataRow drow = dt_empdata.Rows[i];
                Employee_BAL emp = new Employee_BAL();
                emp.EmployeeID = Convert.ToInt32(drow["EmployeeID"]);
                emp.FirstName = drow["FirstName"].ToString();
                emp.LastName = drow["LastName"].ToString();
                emp.Title = drow["Title"].ToString();
                emp.BirthDate = Convert.ToDateTime(drow["BirthDate"]);
                emplist.Add(emp);

            }
            return emplist;


        }


        public bool DeleteEmployee(int empid)
        {

            DataTable dt_empdata = Connect();
            DataRow drow = ds.Tables["employees"].Rows.Find(empid);
            drow.Delete();

            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["employees"]);//record added to the (original)database table
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;


        }


        public bool InsertEmployee(Employee_BAL employee)
        {
            DataTable dt_empdata = Connect();

            DataRow drow = ds.Tables["employees"].NewRow();//creates new row in the datatable
            //drow["EmployeeID"] = employee.EmployeeID;
            drow["FirstName"] = employee.FirstName;
            drow["LastName"] = employee.LastName;
            drow["Title"] = employee.Title;
            drow["BirthDate"] = employee.BirthDate;

            ds.Tables["employees"].Rows.Add(drow);// disconnected mode- inthe dataset

            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            int i = da.Update(ds.Tables["employees"]);//record added to the (original)database table
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;



        }
    }
}
