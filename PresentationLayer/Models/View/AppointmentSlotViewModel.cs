namespace PresentationLayer.Models.View
{
    public class AppointmentSlotViewModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Description { get; set; }
        public string? OrganizerName { get; set; }
        public string? ParticipantName { get; set; }
        public string? Name { set; get; }
        public string? Text => Name;
        public string Status { get; set; } = "free";
    }
}

