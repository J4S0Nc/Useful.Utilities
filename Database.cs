using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Useful.Utilities
{
    /// <summary>
    /// SQL Database functions
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        /// <param name="connection">The connection string.</param>
        public Database(string connection) { Connection = connection; }

        /// <summary>
        /// The database connection string.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Parses the connection string in to a <see cref="SqlConnectionStringBuilder"/>
        /// </summary>
        /// <returns></returns>
        public SqlConnectionStringBuilder ConnectionParts() { return new SqlConnectionStringBuilder(Connection); }

        /// <summary>
        /// Parses the connection string in to a <see cref="SqlConnectionStringBuilder"/>
        /// </summary>
        /// <param name="connection">The connection string to parse</param>
        /// <returns></returns>
        public static SqlConnectionStringBuilder ConnectionParts(string connection) { return new SqlConnectionStringBuilder(connection); }



        /// <summary>
        /// Tests the connection.
        /// </summary>
        /// <param name="throwOnError">Flag to throw or hide connection errors</param>
        /// <returns>True if successful</returns>
        public bool TestConnection(bool throwOnError = true)
        {
            return TestConnection(Connection, throwOnError);
        }

        /// <summary>
        /// Tests the connection.
        /// </summary>
        /// <param name="connection">The connection string.</param>
        /// <param name="throwOnError">Flag to throw or hide connection errors</param>
        /// <returns>
        /// True if successful
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Connection string must have Data Source and Initial Catalog both set</exception>
        public static bool TestConnection(string connection, bool throwOnError = true)
        {

            Trace.WriteLine("SQL Testing Connection " + connection);
            try
            {
                var parts = ConnectionParts(connection);
                if (parts == null || string.IsNullOrWhiteSpace(parts.DataSource) || string.IsNullOrWhiteSpace(parts.InitialCatalog))
                {
                    throw new ArgumentNullException("connection", "Connection string not set! Make sure Data Source and Initial Catalog are both set");
                }
                using (var conn = new SqlConnection(connection))
                {
                    conn.Open();
                    conn.Close();
                }
                Trace.WriteLine("SQL Testing Connection Passed!");
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("SQL Testing Connection Failed! " + ex.Message);
                if (throwOnError)
                    throw;
                return false;
            }

        }
        /// <summary>
        /// Gets a list of all available instances of SQL Server within the local network.
        /// </summary>
        /// <value>
        /// string array of server names
        /// </value>
        public static string[] Servers
        {
            get
            {
                List<string> rtn = new List<string>();
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                foreach (DataRow row in servers.Rows)
                {
                    if ((row["InstanceName"] as string) != null)
                        rtn.Add(row["ServerName"] + "\\" + row["InstanceName"]);
                    else
                        rtn.Add(row["ServerName"] as string);

                }
                rtn.Sort();
                return rtn.ToArray();

            }
        }

        /// <summary>
        /// Gets a list of databases on a given server. To use NT Auth leave user/pass blank
        /// </summary>
        /// <param name="server">Server to connect to</param>
        /// <param name="username">SQL Auth user. To use NT Auth leave blank</param>
        /// <param name="password">SQL Auth password</param>
        /// <returns>string array of database names</returns>
        public static string[] Databases(string server, string username = "", string password = "")
        {

            var rtn = new List<string>();

            var constr = new SqlConnectionStringBuilder { DataSource = server, ConnectTimeout = 3 };
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                constr.IntegratedSecurity = true;
            else
            {
                constr.UserID = username;
                constr.Password = password;
            }

            using (var con = new SqlConnection(constr.ConnectionString))
            {
                con.Open();
                DataTable databases = con.GetSchema("Databases");
                rtn.AddRange(from DataRow database in databases.Rows select database.Field<string>("database_name"));
            }

            rtn.Sort();
            return rtn.ToArray();

        }

        /// <summary>
        /// Executes a non query.
        /// </summary>
        /// <param name="sql">SQL statement to execute</param>
        /// <param name="connection">SQL connection string</param>
        public static void ExecuteSql(string sql, string connection)
        {
            var sqlCmd = new SqlCommand(sql);
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                sqlCmd.Connection = conn;
                sqlCmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes a scalar
        /// </summary>
        /// <param name="sqlCmd">The command to execute</param>
        /// <param name="connection">SQL connection string</param>
        /// <returns>Scalar result</returns>
        public static object ExecuteScalar(SqlCommand sqlCmd, string connection)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                sqlCmd.Connection = conn;
                return sqlCmd.ExecuteScalar();
            }
        }

        public static int ExecuteScalarAsInt(SqlCommand sqlCmd, string connection, int nullValue = 0)
        {
            var rtn = ExecuteScalar(sqlCmd, connection);
            int value;
            if (rtn != null && int.TryParse(rtn.ToString(), out value))
                return value;
            return nullValue;
        }

        /// <summary>
        /// Executes a non query.
        /// </summary>
        /// <param name="sqlCmd">The command to execute</param>
        /// <param name="connection">SQL connection string</param>
        public static void ExecuteNonQuery(SqlCommand sqlCmd, string connection)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                sqlCmd.Connection = conn;
                sqlCmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Executes a scalar and attempts to parse the result to integer. If parse fails -1 is returned
        /// </summary>
        /// <param name="sqlCmd">The command to execute</param>
        /// <param name="connection">SQL connection string</param>
        /// <returns>Scalar result as integer or -1</returns>
        public static int ExecuteCount(SqlCommand sqlCmd, string connection)
        {
            var rtn = ExecuteScalar(sqlCmd, connection);
            int count;
            if (int.TryParse(rtn.ToString(), out count))
                return count;
            return -1;
        }

        /// <summary>
        /// Executes a stored procedure as a non query
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="connection">SQL connection string</param>
        public static void ExecuteStoredProc(string storedProcName, string connection)
        {
            using (var conn = new SqlConnection(connection))
            {
                SqlCommand sqlCmd = new SqlCommand(storedProcName, conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = 120;

                conn.Open();
                sqlCmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// Executes a Sql Adapter and fills a dataset
        /// </summary>
        /// <param name="sqlCmd">The command to execute</param>
        /// <param name="connection">SQL connection string</param>
        /// <returns>A Filled DataSet</returns>
        public static DataSet GetDataset(SqlCommand sqlCmd, string connection)
        {
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection(connection))
            {
                var da = new SqlDataAdapter();
                sqlCmd.Connection = conn;
                da.SelectCommand = sqlCmd;
                //conn.Open();
                da.Fill(ds);
                conn.Close();
            }

            return ds;
        }

        /// <summary>
        /// Run a SQL command and return each row as a dynamic row
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Enumeration of <see cref="DynamicRow"/></returns>
        public static IEnumerable<DynamicRow> Run(string sql, string connection)
        {
            var ds = GetDataset(new SqlCommand(sql), connection);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new DynamicRow(row);
            }
        }

    }
}
