using CP.Abstractions.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CP.Abstractions.Contracts.Staff
{
    public class OperationStatusDTO
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationStatusType Status { get; set; }
        public int TotalErrors { get; set; }
        public List<OperationDetailDTO> Errors { get; set; } = new List<OperationDetailDTO>();
    }

    public class OperationDetailDTO
    {
        public string ErrorMessage { get; set; } = null!;
        public object? Data { get; set; }
    }
}
