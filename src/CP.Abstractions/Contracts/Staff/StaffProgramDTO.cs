using CP.Abstractions.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CP.Abstractions.Contracts.Staff
{
    public class StaffProgramDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        [JsonConverter(typeof(StringEnumConverter))]
        public DefaultStatusType Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = null!;
    }
}
