using System;
using System.Collections.Generic;

namespace WordWeave.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsPremium { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? SubscriptionExpiry { get; set; }


        public ICollection<WordCloudGroup> OwnedGroups { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
    }
}