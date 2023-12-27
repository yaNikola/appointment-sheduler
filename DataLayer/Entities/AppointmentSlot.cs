using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataLayer.Entities
{
    public class AppointmentSlot
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Description { get; set; }
        public string? OrganizerName { get; set; }
        public string? ParticipantName {  get; set; }
        public string? Name {  set; get; }
        public string? Text => Name;

        [JsonPropertyName("patient")]
        public string? PatientId { set; get; }
        public string Status { get; set; } = "free";

    }
}
