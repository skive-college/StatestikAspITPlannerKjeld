using StatestikAspITPlannerKjeld.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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

        public List<Student> getAllStudents()
        {
            List<Student> retur = new List<Student>();
            SqlConnection cnn = new SqlConnection(conString);

            cnn.Open();

            SqlCommand cmd;
            String sql = "SELECT * FROM Students";

            cmd = new SqlCommand(sql, cnn);
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    retur.Add(
                        new Student
                        {
                            ID = int.Parse(oReader["ID"].ToString()),
                            Name = oReader["Name"].ToString(),
                            Team = oReader["Name"].ToString()

                        });
                }

            }
            return retur;
        }

        public static List<ChartValues> getData(int sID)
        {
            List<ChartValues> retur = new List<ChartValues>();
            SqlConnection cnn = new SqlConnection(conString);
            List<regType> regtypes = getAllTypes();
            int[] counts = new int[regtypes.Count];
            cnn.Open();

            SqlCommand cmd;
            String sql = "SELECT * FROM Presents p, Students s where p.StudentID = @StudentID ";

            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("StudentID", sID);
            int ialt = 0;
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    for (int i = 0; i < regtypes.Count; i++)
                    {
                        if (int.Parse(oReader["Model1"].ToString()) == regtypes[i].ID)
                            counts[i]++;
                        if (int.Parse(oReader["Model2"].ToString()) == regtypes[i].ID)
                            counts[i]++;
                        if (int.Parse(oReader["Model3"].ToString()) == regtypes[i].ID)
                            counts[i]++;
                        if (int.Parse(oReader["Model4"].ToString()) == regtypes[i].ID)
                            counts[i]++;

                        ialt++;
                    }
                }

            }
            for(int i = 0; i < regtypes.Count; i++)
            {
                retur.Add(new ChartValues {ID = regtypes[i].ID,  Navn = regtypes[i].TypeName, Procent = getProcent(ialt, counts[i])});
            }
            return retur;
        }

        private static int getProcent(int ialt, int v)
        {
            return (int)(100 * (((double) v) / ((double)ialt)));
        }

        private static List<regType> getAllTypes()
        {
            List<regType> retur = new List<regType>();
            SqlConnection cnn = new SqlConnection(conString);

            cnn.Open();

            SqlCommand cmd;
            String sql = "SELECT * FROM RegistrationTypes";

            cmd = new SqlCommand(sql, cnn);
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    retur.Add(
                        new regType { ID = int.Parse(oReader["ID"].ToString()),
                                      TypeName = oReader["TypeName"].ToString(),
                                      CatID = int.Parse(oReader["CatID"].ToString())

                        });
                }

            }
            return retur;
        }

        public static string getTypeName(int ID)
        {
            string retur = "";
            SqlConnection cnn = new SqlConnection(conString);

            cnn.Open();

            SqlCommand cmd;
            String sql = "SELECT * FROM RegistrationTypes where ID = @ID ";

            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("ID", ID);
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    retur = oReader["TypeName"].ToString();
                }

            }
            return retur;
        }
    }
}
