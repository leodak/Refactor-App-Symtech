using System.Data.SqlClient;

namespace refactor_this
{
    /// <summary>
    /// Class for helpers
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// SQL Connection String
        /// </summary>
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\refactor-this.mdf;Integrated Security=True;Connect Timeout=30";

        /// <summary>
        /// Creates a new SQL Connection
        /// </summary>
        /// <returns>SQL Connection <see cref="SqlConnection"/></returns>
        public static SqlConnection NewConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}