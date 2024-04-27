using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDevelopmentPortal.Models.AdminModels
{
    public class Event
    {
        [Key]
        public long EventId { get; set; }
        public required string EventName { get; set; }
        public required string Description { get; set; }
        public required string EventDate { get; set; }
        public required string EventLocation { get; set; }
        [ForeignKey(nameof(FacultyId))]
        public long FacultyId { get; set; }
    }
}
