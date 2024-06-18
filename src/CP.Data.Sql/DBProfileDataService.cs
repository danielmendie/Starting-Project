using CP.Abstractions.Models;
using CP.Abstractions.Services.Data;
using Dapper;
using System.Data;
using System.Data.Common;

namespace CP.Data.Sql
{
    public class DBProfileDataService : DataLayerBase, IProfileDataService
    {
        public DBProfileDataService(AppSettings appSettings) : base(appSettings)
        {
        }

        public async Task<Profile?> GetProfileById(IDbTransaction? transaction, long ProfileId)
        {
            Profile? retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@ProfileId", ProfileId, DbType.Int64, ParameterDirection.Input);

            //execute 
            var query = await connection.QueryAsync<Profile>("Profile_GetById", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = query.FirstOrDefault();
            return retVal;
        }

        public async Task<long> InsertProfile(IDbTransaction? transaction, string FirstName, string LastName, string Gender, string Email, string Phone, string Nationality, string Address, DateTime DateOfBirth, string Data, string CreatedBy)
        {
            long retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@Id", null, DbType.Int64, ParameterDirection.Output);
            parameters.Add("@FirstName", FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("@LastName", LastName, DbType.String, ParameterDirection.Input);
            parameters.Add("@Gender", Gender, DbType.String, ParameterDirection.Input);
            parameters.Add("@Email", Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@Phone", Phone, DbType.String, ParameterDirection.Input);
            parameters.Add("@Nationality", Nationality, DbType.String, ParameterDirection.Input);
            parameters.Add("@Address", Address, DbType.String, ParameterDirection.Input);
            parameters.Add("@DateOfBirth", DateOfBirth, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@Data", Data, DbType.String, ParameterDirection.Input);
            parameters.Add("@CreatedBy", CreatedBy, DbType.String, ParameterDirection.Input);

            //execute 
            await connection.ExecuteAsync("Profile_Insert", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = parameters.Get<long>("@Id"); return retVal;
        }

    }
}
