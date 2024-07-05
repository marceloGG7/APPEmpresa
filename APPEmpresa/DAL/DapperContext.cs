using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPEmpresa.DAL
{
    public class DapperContext
    {
        private static string Conn = Environment.GetEnvironmentVariable("PROD");

        public static DataTable Funcion_StoreDB(string P_Sentencia, object P_Parametro)
        {
            DataTable Dt = new();

            try
            {
                using (SqlConnection conn = new SqlConnection(Conn))
                {
                    var lst = conn.ExecuteReader(P_Sentencia, P_Parametro, commandType: CommandType.StoredProcedure);
                    Dt.Load(lst);
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return Dt;
        }

        public static void Procedimiento_StoreDB(string P_Sentencia,object P_Parametro)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conn))
                {
                    var lst = conn.ExecuteReader(P_Sentencia, P_Parametro, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException e) 
            {
                throw e;
            }
        }
    }
}
