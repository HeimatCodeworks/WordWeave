using System;
using System.Collections.Generic;

namespace WordWeave.Models
{
    public class WordCloudGroup
    {
        public int WordCloudGroupId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<WordEntry> WordEntries { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
    }
}