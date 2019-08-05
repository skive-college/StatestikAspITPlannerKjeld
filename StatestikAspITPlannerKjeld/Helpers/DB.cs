using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatestikAspITPlannerKjeld.Helpers
{
    public class DB
    {
        private static readonly string conString = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;


        public void getAll()
        {
            List<int> ids = new List<int>();
            SqlConnection cnn = new SqlConnection(conString);
            
            cnn.Open();

            SqlCommand cmd;
            String sql = "SELECT * FROM Presents p, Students s where p.StudentID = s.ID ";
            
            cmd = new SqlCommand(sql, cnn);
            //cmd.Parameters.AddWithValue("StudentID", 7);
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                     int id = int.Parse(oReader["StudentID"].ToString());
                     string name = oReader["Name"].ToString();
                     ids.Add(id);
                }

            }
        }
    }
}
