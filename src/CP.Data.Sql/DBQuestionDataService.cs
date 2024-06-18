using CP.Abstractions.Enum;
using CP.Abstractions.Models;
using CP.Abstractions.Services.Data;
using Dapper;
using System.Data;
using System.Data.Common;

namespace CP.Data.Sql
{
    public class DBQuestionDataService : DataLayerBase, IQuestionDataService
    {
        public DBQuestionDataService(AppSettings appSettings) : base(appSettings)
        {
        }


        public async Task<ProgramQuestion?> GetQuestionById(IDbTransaction? transaction, int QuestionId)
        {
            ProgramQuestion? retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@Id", QuestionId, DbType.Int32, ParameterDirection.Input);

            //execute 
            var query = await connection.QueryAsync<ProgramQuestion>("Question_GetById", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = query.FirstOrDefault();
            return retVal;
        }


        public async Task DeleteQuestion(IDbTransaction? transaction, int Id)
        {
            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32, ParameterDirection.Input);

            //execute 
            await connection.ExecuteAsync("Question_Delete", parameters, transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ProgramQuestion>> GetQuestionsByProgram(IDbTransaction? transaction, long ProgramId)
        {
            IEnumerable<ProgramQuestion> retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@ProgramId", ProgramId, DbType.Int64, ParameterDirection.Input);

            //execute 
            var query = await connection.QueryAsync<ProgramQuestion>("Question_GetByProgram", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = query;
            return retVal;
        }

        public async Task<IEnumerable<QuestionType>> GetQuestionTypes(IDbTransaction? transaction)
        {
            IEnumerable<QuestionType> retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();

            //execute 
            var query = await connection.QueryAsync<QuestionType>("QuestionType_GetAll", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = query;
            return retVal;
        }

        public async Task<QuestionType?> GetQuestionTypeByType(IDbTransaction? transaction, string Type)
        {
            QuestionType? retVal;

            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@Type", Type, DbType.String, ParameterDirection.Input);

            //execute 
            var query = await connection.QueryAsync<QuestionType>("QuestionType_GetByType", parameters, transaction, commandType: CommandType.StoredProcedure);

            retVal = query.FirstOrDefault();
            return retVal;
        }

        public async Task InsertQuestion(IDbTransaction? transaction, string Question, string Data, long ProgramId, string CreatedBy)
        {
            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@Question", Question, DbType.String, ParameterDirection.Input);
            parameters.Add("@Data", Data, DbType.String, ParameterDirection.Input);
            parameters.Add("@ProgramId", ProgramId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@CreatedBy", CreatedBy, DbType.String, ParameterDirection.Input);

            //execute 
            await connection.ExecuteAsync("Question_Insert", parameters, transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateQuestion(IDbTransaction? transaction, int Id, string Question, string Data, DefaultStatusType Status, string ModifiedBy)
        {
            using DbConnection connection = GetDefaultConnection();
            await connection.OpenAsync();

            // specify stored procedure parameters
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("@Question", Question, DbType.String, ParameterDirection.Input);
            parameters.Add("@Data", Data, DbType.String, ParameterDirection.Input);
            parameters.Add("@Status", Status, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ModifiedBy", ModifiedBy, DbType.String, ParameterDirection.Input);

            //execute 
            await connection.ExecuteAsync("Question_Update", parameters, transaction, commandType: CommandType.StoredProcedure);
        }

    }
}
