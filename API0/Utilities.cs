using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace API0
{
    public class Utilities
    {
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA512.Create();  //or use SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string encrypt(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
        public static string FirstDataFromTable(DataTable dt)
        {
            string res;
            DataRow dr = dt.Rows[0];
            res = dr[0].ToString();
            return res;
        }

        public static string DataFromTableRol(DataTable dt)
        {
            string res;
            DataRow dr = dt.Rows[8];
            res = dr[8].ToString();
            return res;
        }



        public static DataTable ExecuteStoredProcedure(string ConnectionString,string stored,Parameter[] parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand(stored);
            for(int i = 0; i< parameters.Length; i++)
            {
                string name = parameters[i].name;
                object value = parameters[i].value;
                com.Parameters.Add(new SqlParameter(name, value));
            }
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = con;
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(com.ExecuteReader());
            con.Close();
            return dt;
        }

        public static string FirstDataFromTable(string ConnectionString,string stored, Parameter[] parameters)
        {
            DataTable dt = ExecuteStoredProcedure(ConnectionString,stored, parameters);
            return FirstDataFromTable(dt);
        }

        public static string DataFromTable(string ConnectionString, string stored, Parameter[] parameters)
        {
            DataTable dt = ExecuteStoredProcedure(ConnectionString, stored, parameters);
            return DataFromTableRol(dt);
        }

     
    }
}
