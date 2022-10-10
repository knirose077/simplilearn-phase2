using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bussinesslogic;

namespace data_access
{
    public class Employee_DAL
    {
        public bool InsertEmployee(Employee_BAL employee)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);

            SqlCommand cmdInsert = new SqlCommand("insert into book(book_id,book_name,book_author) values(@book_id,@book_name,@book_author)", cn);
            cmdInsert.Parameters.AddWithValue("@book_id", employee.book_id);
            cmdInsert.Parameters.AddWithValue("@book_name", employee.book_name);
            cmdInsert.Parameters.AddWithValue("@book_author", employee.book_author);

            /*SqlCommand cmdInserts = new SqlCommand("insert into member(member_id,member_name) values(@member_id,@member_name)", cn);
            cmdInserts.Parameters.AddWithValue("@member_id", employee.memberid);
            cmdInserts.Parameters.AddWithValue("@member_name", employee.membername); */
            

            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();
           
            bool status = false;
            
            if (i == 1)
            {
                status = true;
            }
           
            cn.Close();//finally
            cn.Dispose();//finally
            return status;
    


        }
        public bool InsertEmployees(Employee_BAL employee)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);

          /*  SqlCommand cmdInsert = new SqlCommand("insert into book(book_id,book_name,book_author) values(@book_id,@book_name,@book_author)", cn);
            cmdInsert.Parameters.AddWithValue("@book_id", employee.book_id);
            cmdInsert.Parameters.AddWithValue("@book_name", employee.book_name);
            cmdInsert.Parameters.AddWithValue("@book_author", employee.book_author); */

            SqlCommand cmdInserts = new SqlCommand("insert into member(member_id,member_name) values(@member_id,@member_name)", cn);
            cmdInserts.Parameters.AddWithValue("@member_id", employee.member_id);
            cmdInserts.Parameters.AddWithValue("@member_name", employee.member_name); 


            cn.Open();
            int j = cmdInserts.ExecuteNonQuery();

            bool status = false;

            if (j == 1)
            {
                status = true;
            }

            cn.Close();//finally
            cn.Dispose();//finally
            return status;



        }
        public bool UpdateEmployee(Employee_BAL employee)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[UpdateEmployeeDetails]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_id1", employee.member_id);
            cmdUpdate.Parameters.AddWithValue("@p_name1", employee.member_name);
            cn.Open();
            int s = cmdUpdate.ExecuteNonQuery();
            bool statusd = false;
            if (s == 1)
            {
                statusd = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return statusd;

        }
        public int EmployeeCount()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);

            // SqlCommand cmd1 = new SqlCommand("select * from [dbo].[fn_EmpCount]()", cn);
            // cn.Open();
            //SqlDataReader dr=cmd1.ExecuteReader();
            // int cnt = 0;
            // if (dr.HasRows)
            // {
            //     dr.Read();
            //    cnt=Convert.ToInt32(dr[0]);

            // }
            // return cnt;
            SqlCommand cmd = new SqlCommand("select count(*) from employees", cn);
            cn.Open();

            int cnt = (int)cmd.ExecuteScalar();
            cn.Close();
            cn.Dispose();
            return cnt;
            


        }
        public Employee_BAL FindEmployee(int empid)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindEmployee]", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_bookid", empid);
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_bookname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 10;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_bookauthor";
            p2.SqlDbType = System.Data.SqlDbType.NVarChar;
            p2.Size = 20;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);


          


            cn.Open();
            cmdSelect.ExecuteNonQuery();

            Employee_BAL empfound = new Employee_BAL();

            empfound.book_name = p1.Value.ToString();
            empfound.book_author = p2.Value.ToString();
          




            cn.Close();
            cn.Dispose();


            return empfound;



        }
        public List<Employee_BAL> EmployeeList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  [dbo].[fn_Emplist]()", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<Employee_BAL> emplist = new List<Employee_BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee_BAL bal = new Employee_BAL();
                    bal.book_id = Convert.ToInt32(dr["book_id"]);
                    bal.book_name = dr["book_name"].ToString();
                    bal.book_author = dr["book_author"].ToString();
                  
                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool DeleteEmployee(int employee_id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand("[dbo].[sp_DeleteEmployee]", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_bookid", employee_id);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }



    }
}
