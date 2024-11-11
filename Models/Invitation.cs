using System;

namespace WordWeave.Models
{
    public class Invitation
    {
        public int InvitationId { get; set; }
        public string Email { get; set; }
        public DateTime InvitedAt { get; set; } = DateTime.UtcNow;
        public bool IsAccepted { get; set; } = false;

        public int WordCloudGroupId { get; set; }
        public WordCloudGroup WordCloudGroup { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}