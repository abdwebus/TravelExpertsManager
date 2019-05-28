using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class DB
    {
        public static SqlConnection getConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static DataRowCollection getRows(string sql)
        {
            DataTable table = new DataTable();
            SqlConnection connection = getConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            table.Load(reader);

            return table.Rows;
        }

        public static bool updateRow(SqlCommand command)
        {
            SqlConnection connection = getConnection();
            command.Connection = connection;
            return command.ExecuteNonQuery() > 0;
        }
    }
}
