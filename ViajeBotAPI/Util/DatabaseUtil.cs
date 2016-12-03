using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ViajeBotAPI.FormFlows;

namespace ViajeBotAPI.Util
{
    public static class DatabaseUtil
    {
        private static string _connectionString = ConfigurationManager.AppSettings["SqlConnectionString"];

        public static string GetUserName(InitialInfo parameters)
        {
            var commandText = "SELECT Nome FROM tblUsuarios WHERE CPF=@CPF AND Nascimento=@Birthday";
            var commmandSql = new SqlCommand(commandText);

            commmandSql.Parameters.AddWithValue("@CPF", parameters.CPF);
            commmandSql.Parameters.AddWithValue("@Birthday", parameters.Birthday);

            try
            {
                var name = ExecuteSQLQuery(commmandSql).ToString();
                return name;
            }
            catch
            {
                return string.Empty;
            }
        }

        private static object ExecuteSQLQuery(SqlCommand command)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    command.Connection = connection;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!string.IsNullOrEmpty(reader[0].ToString()))
                            return reader[0];
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return null;
        }
    }
}