using System;

namespace WordWeave.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsPremium { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SubscriptionExpiry { get; set; }
    }
}