using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business;
namespace data
{
    public class bookdetails
    {
        public List<books> GetProducts()
        {
            SqlConnection c = new SqlConnection("Data Source=DESKTOP-LUAVTH3;Initial Catalog=kannan;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select *from bookdetail", c);
            c.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<books> plist = new List<books>();

            while (dr.Read())
            {
                plist.Add(new books { bookid = Convert.ToInt32(dr[0]), bookname = dr[1].ToString(), bookauthor = dr[2].ToString() });

            }
            c.Close();
            c.Dispose();
            return plist;

        }
    }
}
