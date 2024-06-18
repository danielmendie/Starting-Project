using CP.Abstractions.Enum;

namespace CP.Abstractions.Models
{
    public class Program
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DefaultStatusType Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = null!;
    }
}
