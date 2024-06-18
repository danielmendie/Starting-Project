using CP.Abstractions.Contracts.Staff;
using CP.Abstractions.Exceptions;
using CP.Abstractions.Helpers;
using CP.Abstractions.Models;
using CP.Abstractions.Services.Business;
using CP.Abstractions.Services.Data;
using CP.Abstractions.Services.Infrastructure;
using System.Transactions;

namespace CP.Business
{
    public class ProgramService : IProgramService
    {
        readonly IProgramDataService ProgramDataService;
        readonly IQuestionDataService QuestionDataService;
        readonly IMappingService MappingService;

        public ProgramService(IMappingService mappingService,
            IProgramDataService programDataService,
            IQuestionDataService questionDataService)
        {
            MappingService = mappingService;
            ProgramDataService = programDataService;
            QuestionDataService = questionDataService;
        }


        public async Task<IEnumerable<T?>> GetAllPrograms<T>()
        {
            var data = await ProgramDataService.GetAll(null);

            var retVal = MappingService.Map<IEnumerable<T>>(data);

            return retVal;
        }

        public async Task<T?> GetProgramById<T>(int ProgramId)
        {
            var data = await ProgramDataService.GetProgramById(null, ProgramId);

            if (data == null)
            {
                throw new NotFoundException($"Program with Id: {ProgramId} could not be found");
            }

            var additionalProgramInfo = await QuestionDataService.GetQuestionsByProgram(null, data.Id);

            var model = new ProgramDetail { Program = data, AdditionalInformation = additionalProgramInfo.ToList() };

            var retVal = data != null ? MappingService.Map<T>(model) : default(T);

            return retVal;
        }

        public async Task<OperationStatusDTO> CreateProgram(ProgramCreateDTO program)
        {
            OperationStatusDTO result = new OperationStatusDTO();

            //use transaction - if some error occurs, roll back whatever changes were done
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var programId = await ProgramDataService.InsertProgram(null, program.Title, program.Description, "Some User name - normally i would get this from hte auth state");

                foreach (var item in program.AdditionalInformation)
                {
                    var validType = await QuestionDataService.GetQuestionTypeByType(null, item.Type);
                    if (validType == null)
                    {
                        result.TotalErrors += 1;
                        result.Errors.Add(new OperationDetailDTO
                        {
                            ErrorMessage = "Invalid type for input control",
                            Data = item
                        });
                        continue;
                    }

                    if (item.Data.IsValidJson())
                    {
                        await QuestionDataService.InsertQuestion(null, item.Question, item.Data, programId, "creatded by some user");
                    }
                    else
                    {
                        result.TotalErrors += 1;
                        result.Errors.Add(new OperationDetailDTO
                        {
                            ErrorMessage = "Invalid json data format",
                            Data = item.Data
                        });
                    }
                }

                scope.Complete();
            }


            result.Status = result.TotalErrors > 0 ? Abstractions.Enum.OperationStatusType.Failure
                : Abstractions.Enum.OperationStatusType.Success;

            return result;
        }

        public async Task<OperationStatusDTO> UpdateProgram(long ProgramId, ProgramUpdateDTO program)
        {
            OperationStatusDTO result = new OperationStatusDTO();

            var data = await ProgramDataService.GetProgramById(null, ProgramId);

            if (data == null)
            {
                throw new NotFoundException("Program specified could not be found");
            }

            //use transaction - if some error occurs, roll back whatever changes were done
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                foreach (var question in program.AdditionalInformation)
                {
                    var questionData = await QuestionDataService.GetQuestionById(null, question.Id);

                    if (question.Data.IsValidJson())
                    {
                        var validType = await QuestionDataService.GetQuestionTypeByType(null, question.Type);
                        if (validType == null)
                        {
                            result.TotalErrors += 1;
                            result.Errors.Add(new OperationDetailDTO
                            {
                                ErrorMessage = "Invalid type for input control",
                                Data = question
                            });
                            continue;
                        }

                        if (questionData != null && questionData.ProgramId == ProgramId)
                        {
                            await QuestionDataService.UpdateQuestion(null, question.Id, question.Question, question.Data, question.Status, "updated by a user");
                        }
                        else if (questionData != null && questionData.ProgramId != ProgramId)
                        {
                            result.TotalErrors += 1;
                            result.Errors.Add(new OperationDetailDTO
                            {
                                ErrorMessage = "The specified question can be updated. Programs do not match",
                                Data = question
                            });
                        }
                        else
                        {
                            await QuestionDataService.InsertQuestion(null, question.Question, question.Data, ProgramId, "creatded by some user");
                        }
                    }
                    else
                    {
                        result.TotalErrors += 1;
                        result.Errors.Add(new OperationDetailDTO
                        {
                            ErrorMessage = "Invalid json data format",
                            Data = question.Data
                        });
                    }
                }

                scope.Complete();
            }


            result.Status = result.TotalErrors > 0 ? Abstractions.Enum.OperationStatusType.Failure
                : Abstractions.Enum.OperationStatusType.Success;

            return result;
        }
    }
}
