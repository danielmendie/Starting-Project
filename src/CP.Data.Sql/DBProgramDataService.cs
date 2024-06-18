using CP.Abstractions.Enum;
using CP.Abstractions.Models;
using CP.Abstractions.Services.Data;
using Dapper;
using System.Data;
using System.Data.Common;

namespace CP.Data.Sql
{
    public class DBProgramDataService : DataLayerBase, IProgramDataService
    {
        public DBProgramDataService(AppSettings appSettings) : base(appSettings)
        {
        }

        public async Task<Program?> GetProgramById(IDbTransaction? transaction, long ProgramId)
        {
            Program? retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@ProgramId", ProgramId, DbType.Int64, ParameterDirection.Input);

            //execute 
            var query = await connection.QueryAsync<Program>("Program_GetById", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = query.FirstOrDefault();
            return retVal;
        }

        public async Task<long> InsertProgram(IDbTransaction? transaction, string Title, string Description, string CreatedBy)
        {
            long retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@Id", null, DbType.Int64, ParameterDirection.Output);
            parameters.Add("@Title", Title, DbType.String, ParameterDirection.Input);
            parameters.Add("@Description", Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@CreatedBy", CreatedBy, DbType.String, ParameterDirection.Input);

            //execute 
            await connection.ExecuteAsync("Program_Insert", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = parameters.Get<long>("@Id"); return retVal;
        }

        public async Task UpdateProgram(IDbTransaction? transaction, long Id, string Title, string Description, DefaultStatusType Status, string ModifiedBy)
        {
            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@Title", Title, DbType.String, ParameterDirection.Input);
            parameters.Add("@Description", Description, DbType.String, ParameterDirection.Input);
            parameters.Add("@Status", Status, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", ModifiedBy, DbType.String, ParameterDirection.Input);

            //execute 
            await connection.ExecuteAsync("Program_Update", parameters, transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Program>> GetAll(IDbTransaction? transaction)
        {
            IEnumerable<Program> retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();

            //execute 
            var query = await connection.QueryAsync<Program>("Program_GetAll", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = query;
            return retVal;
        }
    }
}
