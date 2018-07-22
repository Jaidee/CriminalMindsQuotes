using System;

namespace CriminalMindsQuotes
{
    public class Quote
    {
        public string Id { get; set; }
        public string QuoteId { get; set; }
        public int LineNo { get; set; }
        public string EpisodeId { get; set; }
        public string CharacterName { get; set; }
        public string QuoteText { get; set; }
        public string PreText { get; set; }
        public string PostText { get; set; }
        public Nullable<DateTimeOffset> CreatedAt { get; set; }
        public Nullable<DateTimeOffset> UpdatedAt { get; set; }
        public string CopyrightInfo { get; set; }
    }
}
