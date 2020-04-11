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
                catch (SqlException) { }
                finally
                {
                    if (cmd.Connection.State == System.Data.ConnectionState.Open)
                        cmd.Connection.Close();
                    cmd.Dispose();
                }
            }

            return result;
        }

        public void ExecuteQuery(string pSpName, object pModel)
        {
            using (SqlCommand cmd = new SqlCommand(pSpName, new SqlConnection(Connection_Car())))
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var prop in pModel.GetType().GetProperties())
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(pModel));
                    }
                    cmd.CommandTimeout = 0;
                    cmd.CommandTimeout = 0;
                    int result = cmd.ExecuteNonQuery();
                }
                catch (SqlException) { }
                finally
                {
                    if (cmd.Connection.State == System.Data.ConnectionState.Open)
                        cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
        }
    }
}
