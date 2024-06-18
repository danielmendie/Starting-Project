using CP.Abstractions.Contracts.Intern;
using CP.Abstractions.Services.Business;
using Microsoft.AspNetCore.Mvc;

namespace CP.Api.Web.Controllers
{
    /// <summary>
    /// form controller
    /// </summary>
    [Tags("Application Form")]
    [Route("v1/forms/{programId:int}")]
    public class FormController : ControllerBase
    {
        private readonly IQuestionService QuestionService;

        /// <summary>
        /// form constructor
        /// </summary>
        public FormController(IQuestionService questionService)
        {
            QuestionService = questionService;
        }


        /// <summary>
        /// Gets application form - gets application form for an intern(existing or old) by a program 
        /// </summary>
        [HttpGet]
        public async Task<ApplicationForm> GetApplicationForm([FromQuery] int? internId, int programId)
        {
            var response = await QuestionService.GetApplicationForm<ApplicationForm>(internId, programId);
            return response;
        }
    }
}
