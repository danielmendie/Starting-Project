using CP.Abstractions.Enum;
using CP.Abstractions.Models;
using System.Data;

namespace CP.Abstractions.Services.Data
{
    public interface IProgramDataService
    {
        Task<IEnumerable<Program>> GetAll(IDbTransaction? transaction);
        Task<Program?> GetProgramById(IDbTransaction? transaction, long ProgramId);
        Task<long> InsertProgram(IDbTransaction? transaction, string Title, string Description, string CreatedBy);
        Task UpdateProgram(IDbTransaction? transaction, long Id, string Title, string Description, DefaultStatusType Status, string ModifiedBy);
    }
}
