using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarRent.Database
{
    public class Connection
    {
        public static string Connection_Car()
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnStr_CarRental"].ConnectionString;
            return conn;
        }

        public List<T> ExecuteQuery<T>(string pSpName, List<string> pParam)
        {
            List<T> result = new List<T>();
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(pSpName, new SqlConnection(Connection_Car())))
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var param in pParam)
                    {
                        cmd.Parameters.AddWithValue("@" +param, param);
                    }
                    cmd.CommandTimeout = 0;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandTimeout = 0;
                    dt.Clear();
                    da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = dt.Rows[i];
                        T item = (T)Activator.CreateInstance(typeof(T));
                        foreach (var prop in typeof(T).GetProperties())
                        {
                            prop.SetValue(item, row[prop.Name]);
                        }
                        result.Add(item);
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                        cmd.Connection.Close();
                    cmd.Dispose();
                }
            }

            return result;
        }

        public int ExecuteQuery(string pSpName, object pModel)
        {
            int result = 0;

            using (SqlCommand cmd = new SqlCommand(pSpName, new SqlConnection(Connection_Car())))
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(pModel != null)
                    {
                        foreach (var prop in pModel.GetType().GetProperties())
                        {
                            cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(pModel));
                        }
                    }
                    cmd.CommandTimeout = 0;
                    result = int.Parse(cmd.ExecuteScalar().ToString());
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                        cmd.Connection.Close();
                    cmd.Dispose();
                }
            }

            return result;
        }

        public void ExecuteNonQuery(string pSpName, object pParam)
        {
            using (SqlCommand cmd = new SqlCommand(pSpName, new SqlConnection(Connection_Car())))
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (pParam != null)
                    {
                        foreach (var prop in pParam.GetType().GetProperties())
                        {
                            cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(pParam));
                        }
                    }
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                        cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
        }
    }
}
