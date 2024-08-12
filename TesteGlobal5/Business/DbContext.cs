using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace TesteGlobal5.Business
{
    public class DbContext 
    {
        public string StrConn = "Server=DESKTOP-KKFLKEQ; Database=TesteGlobal5;User Id=sa;Password=root; Trusted_Connection=True;";
        //Database=TesteGlobal5;User Id=sa;Password=root
        SqlConnection conn = null;
        SqlCommand cmd = null;
        public DbContext() {

            conn = new SqlConnection(StrConn);
        }

   
        public DataTable GetDataTable(string name_proc, List<SqlParameter> parms = null)
        {
            try
            {
                conn.Open();    
                DataTable dt = new DataTable();
                cmd = new SqlCommand(name_proc, conn);
                cmd.CommandType  = CommandType.StoredProcedure;
                AddParameters(parms);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void AddParameters(List<SqlParameter> parms)
        {
            if (parms != null)
            {
                foreach (SqlParameter item in parms)
                {
                    cmd.Parameters.Add(item);
                }

            }
            
        }

        public int ExecuteQuery(string name_proc, List<SqlParameter> parms)
        {
            try
            {
                conn.Open();
               
                 cmd = new SqlCommand(name_proc, conn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 AddParameters(parms);
                int retorno = cmd.ExecuteNonQuery();

                conn.Close();

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}