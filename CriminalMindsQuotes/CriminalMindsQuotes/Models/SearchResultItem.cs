using System;

namespace CriminalMindsQuotes
{
    public class SearchResultItem
    {
        public string EpisodeId { get; set; }
        public string EpisodeKeyText { get; set; } // Like S01E01 or Season 1 - Episode 1 ?
        public string QuoteTime { get; set; }
        public string QuoteText { get; set; }
        public string QuoteAuthor { get; set; }
        public string QuotedBy { get; set; }
    }
}
