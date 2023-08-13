using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SIS.Data
{
    public class DataAccess
    {
        private SqlConnection con = null;
        //public string ConnectionString = @"Data Source=PK-LHR-ITS-060;Initial Catalog=Test2SIS;Integrated Security=True";
        //public string ConnectionString = @"Data Source=LAP-NFS197\SQLEXPRESS;Initial Catalog=TestSIS;Persist Security Info=True;User ID=sa;Password=wfs";
        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
        #region constructor

        public DataAccess()
        {
            con = new SqlConnection(ConnectionString);
        }

        #endregion

        public DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            SqlCommand cmd = null;
            DataTable table = new DataTable();

            cmd = con.CreateCommand();

            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;

            try
            {
                con.Open();

                SqlDataAdapter da = null;
                using (da = new SqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                con.Close();
            }

            return table;
        }

        public DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
        {
            SqlCommand cmd = null;
            DataTable table = new DataTable();

            cmd = con.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(param);

            try
            {
                con.Open();

                SqlDataAdapter da = null;
                using (da = new SqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                con.Close();
            }

            return table;
        }

        public bool ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            SqlCommand cmd = null;
            int res = 0;

           

            try
            { cmd = con.CreateCommand();

            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(pars);
                con.Open();

                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                con.Close();
            }

            if (res >= 1)
            {
                return true;
            }
            return false;
        }
        public bool ExecuteNonQuery(SqlCommand Command, CommandType cmdType, SqlParameter[] pars)
        {
            SqlCommand cmd = Command;
            int res = 0;

            cmd = con.CreateCommand();

            cmd.CommandType = cmdType;
            //cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(pars);

            try
            {
                con.Open();

                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                con.Close();
            }

            if (res >= 1)
            {
                return true;
            }
            return false;
        }

        public Int32 ExecuteScalarQuery(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            SqlCommand cmd = null;
            Int32 res;
            try
            {
            cmd = con.CreateCommand();

            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(pars);

                con.Open();

                res = (Int32)cmd.ExecuteScalar();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                con.Close();
            }


            return res;
        }

        public void ExecuteScalarQuery2(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            SqlCommand cmd = null;
            Int32 res;
            try
            {
                cmd = con.CreateCommand();

                cmd.CommandType = cmdType;
                cmd.CommandText = CommandName;
                cmd.Parameters.AddRange(pars);
                con.Open();
                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                con.Close();
            }
        }

    }
}
