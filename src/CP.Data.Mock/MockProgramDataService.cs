using CP.Abstractions.Enum;
using CP.Abstractions.Models;
using CP.Abstractions.Services.Data;
using System.Data;

namespace CP.Data.Mock
{
    public class MockProgramDataService : IProgramDataService
    {
        List<Program> items = new List<Program>();

        public MockProgramDataService()
        {
            SetupData();
        }

        public Task<IEnumerable<Program>> GetAll(IDbTransaction? transaction)
        {
            return Task.FromResult(items as IEnumerable<Program>);
        }

        public Task<Program?> GetProgramById(IDbTransaction? transaction, long ProgramId)
        {
            var data = items.FirstOrDefault(n => n.Id == ProgramId);
            return Task.FromResult(data);
        }


        public Task<long> InsertProgram(IDbTransaction? transaction, string Title, string Description, string CreatedBy)
        {
            long Id = items.Count + 1;
            var model = new Program
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Status = DefaultStatusType.Active,
                CreatedOn = DateTime.Now,
                ModifiedBy = "SYSTEM",
                CreatedBy = "SYSTEM",
                ModifiedOn = DateTime.Now,
            };
            items.Add(model);
            return Task.FromResult(Id);
        }

        public Task UpdateProgram(IDbTransaction? transaction, long Id, string Title, string Description, DefaultStatusType Status, string ModifiedBy)
        {
            var programToEdit = items.FirstOrDefault(k => k.Id == Id);
            if (programToEdit != null)
            {
                items.Remove(programToEdit);
                programToEdit.Title = Title;
                programToEdit.Description = Description;
                programToEdit.Status = Status;
                programToEdit.ModifiedBy = ModifiedBy;
                programToEdit.ModifiedOn = DateTime.Now;
                items.Add(programToEdit);
            }

            return Task.CompletedTask;
        }

        void SetupData()
        {
            items = new List<Program>()
            {
                new Program
                {
                     Id =  1,
                     Title  = "2024 Internship",
                     Description = "Oh yeah, this year is gonna be wow",
                     Status = DefaultStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                },
                new Program
                {
                     Id =  2,
                     Title  = "2024 Fan House Group",
                     Description = "Oh yeah, this year is gonna be wow",
                     Status = DefaultStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                }
            };
        }
    }
}
