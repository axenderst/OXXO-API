using System;
using System.Data.SqlClient;

namespace Oxxo2.Models
{
    public static class ConectarBD
    {

        public static string ConexionBD()
        {
            string _out = "Conexión a la B.D. exitosa";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=VORTIZ\SQLSERVER2012;Initial Catalog=TEST;Integrated Security=True";
            try
            {
                conn.Open();

            } catch (SqlException ex)
            {
                throw ex;
            }
            return _out;

        }

       

        var INSSQL = "SELECT Usuario from TEST.dbo.USERS WHERE IdUser = 1;";
                var CMDSQL = new SqlCommand(INSSQL, conn);
    }
                //CMDSQL.Parameters.Add(new SqlParameter("cvepai", wvcepai));
                using (SqlDataReader reader = CMDSQL.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        _out = (string)reader["DesPai"];
                    }
                    else
                    {
                        _out = "No existe en catalogo.";
                    }
                    System.Console.WriteLine(_out);
                    reader.Close();
                }
                conn.Close();

            return _out;
        }

            
        }
    }
}
