using CP.Abstractions.Enum;
using CP.Abstractions.Models;
using CP.Abstractions.Services.Data;
using System.Data;

namespace CP.Data.Mock
{
    public class MockProfileDataService : IProfileDataService
    {
        List<Profile> items = new List<Profile>();

        public MockProfileDataService()
        {
            SetupData();
        }

        public Task<Profile?> GetProfileById(IDbTransaction? transaction, long ProfileId)
        {
            var data = items.FirstOrDefault(n => n.Id == ProfileId);
            return Task.FromResult(data);
        }

        public Task<long> InsertProfile(IDbTransaction? transaction, string FirstName, string LastName, string Gender, string Email, string Phone, string Nationality, string Address, DateTime DateOfBirth, string Data, string CreatedBy)
        {
            long Id = items.Count + 1;
            var model = new Profile
            {
                Id = Id,
                Address = Address,
                Gender = Gender,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Nationality = Nationality,
                Phone = Phone,
                DateOfBirth = DateOfBirth,
                Data = Data,
                Status = ProfileStatusType.Active,
                CreatedOn = DateTime.Now,
                ModifiedBy = "SYSTEM",
                CreatedBy = "SYSTEM",
                ModifiedOn = DateTime.Now,
            };
            items.Add(model);
            return Task.FromResult(Id);
        }

        void SetupData()
        {
            items = new List<Profile>()
            {
                new Profile
                {
                     Id =  1,
                     Address = "Cool dev street",
                     Gender = "male",
                     Email = "johndeo@mail.com",
                     FirstName = "John",
                     LastName = "Doe",
                     Nationality = "The world",
                     Phone = "2348967856",
                     DateOfBirth = DateTime.Now.AddYears(-47),
                     Data  = "",
                     Status = ProfileStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                }
            };
        }
    }
}
