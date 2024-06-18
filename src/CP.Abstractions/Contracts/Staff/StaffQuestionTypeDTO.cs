using CP.Abstractions.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CP.Abstractions.Contracts.Staff
{
    public class StaffQuestionTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Data { get; set; } = null!;
        [JsonConverter(typeof(StringEnumConverter))]
        public DefaultStatusType Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = null!;
    }
}
