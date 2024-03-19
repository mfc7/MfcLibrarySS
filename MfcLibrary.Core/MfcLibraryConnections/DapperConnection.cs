using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MfcLibrary.Core.MfcLibraryConnections
{

    /// <summary>
    /// Dapper connection with SQL.
    /// </summary>
    public class DapperConnection
    {

        private readonly IConfiguration configuration;

        /// <summary>
        /// Configuration for Dapper connection.
        /// </summary>
        /// <param name="configuration"></param>
        public DapperConnection(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Creating connection with database.
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(configuration.GetConnectionString("myConnectionToSql"));
            // myConnectionToSql in appsetting.json
        }

    }
}
