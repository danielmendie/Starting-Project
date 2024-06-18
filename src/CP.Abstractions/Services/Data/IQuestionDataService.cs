using CP.Abstractions.Enum;
using CP.Abstractions.Models;
using System.Data;

namespace CP.Abstractions.Services.Data
{
    public interface IQuestionDataService
    {
        Task DeleteQuestion(IDbTransaction? transaction, int Id);
        Task<ProgramQuestion?> GetQuestionById(IDbTransaction? transaction, int QuestionId);
        Task<IEnumerable<ProgramQuestion>> GetQuestionsByProgram(IDbTransaction? transaction, long ProgramId);
        Task<QuestionType?> GetQuestionTypeByType(IDbTransaction? transaction, string Type);
        Task<IEnumerable<QuestionType>> GetQuestionTypes(IDbTransaction? transaction);
        Task InsertQuestion(IDbTransaction? transaction, string Question, string Data, long ProgramId, string CreatedBy);
        Task UpdateQuestion(IDbTransaction? transaction, int Id, string Question, string Data, DefaultStatusType Status, string ModifiedBy);
    }
}
