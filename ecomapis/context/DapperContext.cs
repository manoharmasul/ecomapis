using System.Data;
using System.Data.SqlClient;

namespace productcrudforangular.context
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionstring;
        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionstring = this.configuration.GetConnectionString("sqlconnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
    }
}
