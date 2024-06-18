using CP.Abstractions.Models;
using System.Data;

namespace CP.Abstractions.Services.Data
{
    public interface IProfileDataService
    {
        Task<Profile?> GetProfileById(IDbTransaction? transaction, long ProfileId);
        Task<long> InsertProfile(IDbTransaction? transaction, string FirstName, string LastName, string Gender, string Email, string Phone, string Nationality, string Address, DateTime DateOfBirth, string Data, string CreatedBy);
    }
}
