using CP.Abstractions.Contracts.Intern;
using CP.Abstractions.Services.Business;
using CP.Api.Web.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace CP.Api.Web.Controllers
{
    /// <summary>
    /// intern application controller
    /// </summary>
    [Tags("Apply")]
    [Route("v1/apply")]
    public class ApplyController : ControllerBase
    {
        private readonly IQuestionService QuestionService;

        /// <summary>
        /// apply constructor
        /// </summary>
        public ApplyController(IQuestionService questionService)
        {
            QuestionService = questionService;
        }

        /// <summary>
        /// Submit application form - submits internship application form
        /// </summary>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> SubmitForm([FromBody] ApplicationSubmitDTO applicationForm)
        {
            await QuestionService.SubmitForm(applicationForm);
            return Created();
        }
    }
}
