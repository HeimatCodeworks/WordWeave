using System;

namespace WordWeave.Models
{
    public class WordEntry
    {
        public int WordEntryId { get; set; }
        public string Word { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public int WordCloudGroupId { get; set; }
        public WordCloudGroup WordCloudGroup { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}