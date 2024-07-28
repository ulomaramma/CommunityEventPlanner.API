

using System.ComponentModel.DataAnnotations;
using static CommunityEventPlanner.Client.Validations.DateValidation;

namespace CommunityEventPlanner.Client.Models.Events
{
    public class CreateEventRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateGreaterOrEqualToToday(ErrorMessage = "Start date must be today or a future date.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DateGreaterThan(nameof(StartDate), ErrorMessage = "End date must be greater than the start date.")]
        public DateTime? EndDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Required]
        public string Location { get; set; }

        public bool IsPhysical { get; set; }

        public string AccessLink { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public bool IsFree { get; set; }

        public decimal Cost { get; set; }

        [Required]
        public int Capacity { get; set; }

    }
}
