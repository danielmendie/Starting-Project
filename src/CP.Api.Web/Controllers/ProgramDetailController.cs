using CP.Abstractions.Contracts.Staff;
using CP.Abstractions.Services.Business;
using Microsoft.AspNetCore.Mvc;

namespace CP.Api.Web.Controllers
{
    /// <summary>
    /// program detail controller
    /// </summary>
    [Tags("Staff")]
    [Route("v1/programs/{programId:int}")]
    public class ProgramDetailController : Controller
    {
        private readonly IProgramService ProgramService;

        /// <summary>
        /// Program detail Controller constructor
        /// </summary>
        public ProgramDetailController(IProgramService programService)
        {
            ProgramService = programService;
        }


        /// <summary>
        /// Gets program info - gets a program info
        /// </summary>
        [HttpGet]
        public async Task<Abstractions.Contracts.Staff.ProgramDetailDTO?> GetProgramDetail(int programId)
        {
            var response = await ProgramService.GetProgramById<Abstractions.Contracts.Staff.ProgramDetailDTO>(programId);
            return response;
        }


        /// <summary>
        /// Update program info - update a program info
        /// </summary>
        [HttpPut]
        public async Task<Abstractions.Contracts.Staff.OperationStatusDTO?> GetProgramDetail(int programId, [FromBody] ProgramUpdateDTO program)
        {
            var response = await ProgramService.UpdateProgram(programId, program);
            return response;
        }
    }
}
