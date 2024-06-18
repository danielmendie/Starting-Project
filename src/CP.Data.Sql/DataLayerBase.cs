using CP.Abstractions.Models;
using System.Data.Common;
using System.Data.SqlClient;

namespace CP.Data.Sql
{
    public class DataLayerBase
    {
        readonly AppSettings AppSettings;
        public DataLayerBase(AppSettings appSettings)
        {
            AppSettings = appSettings;
        }

        protected DbConnection GetDefaultConnection()
        {
            return new SqlConnection(AppSettings.ConnectionStrings.ConnectionString);
        }
    }
}
