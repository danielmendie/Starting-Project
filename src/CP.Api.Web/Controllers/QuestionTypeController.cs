using CP.Abstractions.Services.Business;
using Microsoft.AspNetCore.Mvc;

namespace CP.Api.Web.Controllers
{
    /// <summary>
    /// question type controller
    /// </summary>
    [Tags("Staff")]
    [Route("v1/questiontypes")]
    public class QuestionTypeController : Controller
    {
        private readonly IQuestionService QuestionService;

        /// <summary>
        /// QuestionTypeController constructor
        /// </summary>
        public QuestionTypeController(IQuestionService questionService)
        {
            QuestionService = questionService;
        }

        /// <summary>
        /// Gets all question types - gets all question types
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Abstractions.Contracts.Staff.StaffQuestionTypeDTO?>> GetProgramTypes()
        {
            var response = await QuestionService.GetQuestionTypes<Abstractions.Contracts.Staff.StaffQuestionTypeDTO>();
            return response;
        }

    }
}
