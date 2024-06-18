using CP.Abstractions.Enum;

namespace CP.Abstractions.Models
{
    public class ProgramQuestion
    {
        public int Id { get; set; }
        public long ProgramId { get; set; }
        public string Question { get; set; } = null!;
        public string Data { get; set; } = null!;
        public DefaultStatusType Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = null!;

    }
}
