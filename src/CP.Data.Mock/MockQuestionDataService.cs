using CP.Abstractions.Enum;
using CP.Abstractions.Models;
using CP.Abstractions.Services.Data;
using System.Data;

namespace CP.Data.Mock
{
    public class MockQuestionDataService : IQuestionDataService
    {
        List<ProgramQuestion> items = new List<ProgramQuestion>();
        List<QuestionType> types = new List<QuestionType>();

        public MockQuestionDataService()
        {
            SetupData();
        }

        public Task DeleteQuestion(IDbTransaction? transaction, int Id)
        {
            return Task.CompletedTask;
        }

        public Task<ProgramQuestion?> GetQuestionById(IDbTransaction? transaction, int QuestionId)
        {
            var data = items.FirstOrDefault(n => n.Id == QuestionId);
            return Task.FromResult(data);
        }

        public Task<IEnumerable<ProgramQuestion>> GetQuestionsByProgram(IDbTransaction? transaction, long ProgramId)
        {
            var data = items.Where(n => n.ProgramId == ProgramId);
            return Task.FromResult(data);
        }

        public Task<QuestionType?> GetQuestionTypeByType(IDbTransaction? transaction, string Type)
        {
            var data = types.FirstOrDefault(n => n.Type.Equals(Type, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(data);
        }

        public Task<IEnumerable<QuestionType>> GetQuestionTypes(IDbTransaction? transaction)
        {
            return Task.FromResult(types as IEnumerable<QuestionType>);
        }

        public Task InsertQuestion(IDbTransaction? transaction, string Question, string Data, long ProgramId, string CreatedBy)
        {
            var model = new ProgramQuestion
            {
                Id = items.Count + 1,
                ProgramId = ProgramId,
                Question = Question,
                Data = Data,
                Status = DefaultStatusType.Active,
                CreatedOn = DateTime.Now,
                ModifiedBy = "SYSTEM",
                CreatedBy = "SYSTEM",
                ModifiedOn = DateTime.Now,
            };
            items.Add(model);
            return Task.CompletedTask;
        }

        public Task UpdateQuestion(IDbTransaction? transaction, int Id, string Question, string Data, DefaultStatusType Status, string ModifiedBy)
        {
            var questionToEdit = items.FirstOrDefault(k => k.Id == Id);
            if (questionToEdit != null)
            {
                items.Remove(questionToEdit);
                questionToEdit.Question = Question;
                questionToEdit.Status = Status;
                questionToEdit.Data = Data;
                questionToEdit.ModifiedBy = ModifiedBy;
                questionToEdit.ModifiedOn = DateTime.Now;
                items.Add(questionToEdit);
            }

            return Task.CompletedTask;
        }

        void SetupData()
        {
            items = new List<ProgramQuestion>()
            {
                new ProgramQuestion
                {
                     Id =  1,
                     ProgramId = 1,
                     Question = "What is your name?",
                     Data = string.Empty,
                     Status = DefaultStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                },
                new ProgramQuestion
                {
                     Id =  2,
                     ProgramId = 1,
                     Question = "Your Nationality?",
                     Data = string.Empty,
                     Status = DefaultStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                },
                new ProgramQuestion
                {
                     Id =  3,
                     ProgramId = 7,
                     Question = "Are you a software developer?",
                     Data = string.Empty,
                     Status = DefaultStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                }
            };

            types = new List<QuestionType>()
            {
                 new QuestionType
                 {
                      Id = 1,
                      Data = "{\"inputType\":\"Paragraph\",\"inputSetting\":{\"maximumAllowed\":null,\"mininumAllowed\":\"1\"}}",
                      Type = "Paragraph",
                      Status = DefaultStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                 },
                 new QuestionType
                 {
                      Id = 2,
                      Data = "{\"inputType\":\"YesNo\",\"inputOptions\":[\"True\",\"False\"]}",
                      Type = "YesNo",
                      Status = DefaultStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                 },
                 new QuestionType
                 {
                      Id = 3,
                      Data = "{\"inputType\":\"DropDown\",\"inputOptions\":[]}",
                      Type = "DropDown",
                      Status = DefaultStatusType.Active,
                     CreatedOn = DateTime.Now,
                     ModifiedBy = "SYSTEM",
                     CreatedBy = "SYSTEM",
                     ModifiedOn = DateTime.Now,
                 },

            };
        }
    }
}
