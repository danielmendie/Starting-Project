using CP.Abstractions.Contracts.Intern;
using CP.Abstractions.Models;
using CP.Abstractions.Services.Business;
using CP.Abstractions.Services.Data;
using CP.Abstractions.Services.Infrastructure;
using Newtonsoft.Json;

namespace CP.Business
{
    public class QuestionService : IQuestionService
    {
        readonly IQuestionDataService QuestionDataService;
        readonly IProfileDataService ProfileDataService;
        readonly IProgramDataService ProgramDataService;
        readonly IMappingService MappingService;

        public QuestionService(IMappingService mappingService,
            IQuestionDataService questionDataService,
            IProfileDataService profileDataService,
            IProgramDataService programDataService)
        {
            MappingService = mappingService;
            QuestionDataService = questionDataService;
            ProfileDataService = profileDataService;
            ProgramDataService = programDataService;
        }

        public async Task<T> GetApplicationForm<T>(int? InternId, int ProgramId)
        {
            if (ProgramId < 1)
            {
                throw new Exception("Program Id required*");
            }

            var program = await ProgramDataService.GetProgramById(null, ProgramId);
            if (program == null)
            {
                throw new Exception("Specified program not available");
            }

            Profile profile = new Profile();
            if (InternId.HasValue)
            {
                //retrieve existing profile
                var data = await ProfileDataService.GetProfileById(null, InternId.Value);
                if (data is null)
                {
                    profile = new Profile() //initialize profile with empty string
                    {
                        Address = "no data",
                        Email = "no data",
                        FirstName = "no data",
                        Gender = "no data",
                        LastName = "no data",
                        Nationality = "no data",
                        Phone = "no data",
                        DateOfBirth = DateTime.Now
                    };
                }
            }

            AdditionaInfo? AdditionalInformation = null;
            //return previous answer as part of existing form
            if (!string.IsNullOrWhiteSpace(profile.Data))
            {
                AdditionalInformation = JsonConvert.DeserializeObject<AdditionaInfo>(profile.Data);
            }

            var questions = await QuestionDataService.GetQuestionsByProgram(null, program.Id);

            var form = new FormDetail { Program = program, AdditionalQuestions = questions.ToList(), Profile = profile, Answers = AdditionalInformation?.AddittionalInformation };

            //map to contract
            var retVal = MappingService.Map<T>(form);

            return retVal;
        }

        public async Task SubmitForm(ApplicationSubmitDTO applicant)
        {
            var program = await ProgramDataService.GetProgramById(null, applicant.ProgramId);
            if (program is null)
            {
                throw new Exception("Valid program type is required*");
            }

            var extraData = new AdditionaInfo { ProgramId = applicant.ProgramId, AddittionalInformation = applicant.AdditionalInformation };
            var data = JsonConvert.SerializeObject(extraData);

            //create intern profile
            var profile = await ProfileDataService.InsertProfile(null, applicant.FirstName, applicant.LastName, applicant.Gender, applicant.Email, applicant.Phone, applicant.Nationality, applicant.Address, applicant.DateOfBirth, data, $"{applicant.FirstName} {applicant.LastName}");
        }

        public async Task<IEnumerable<T>> GetQuestionTypes<T>()
        {
            var data = await QuestionDataService.GetQuestionTypes(null);

            var retVal = MappingService.Map<IEnumerable<T>>(data);

            return retVal;
        }
    }
}
