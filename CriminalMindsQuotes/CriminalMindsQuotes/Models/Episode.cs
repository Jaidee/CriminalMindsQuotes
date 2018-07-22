using System;

namespace CriminalMindsQuotes
{
    public class Episode
    {
        public string Id { get; set; }
        public string EpisodeId { get; set; }
        public DateTime AirDate { get; set; }
        public string Title { get; set; }
        public string PlotSummary { get; set; }
        public string ImdbLink { get; set; }
        public string TvdbLink { get; set; }
        public string Quote_01 { get; set; }
        public string Quote_01_Author { get; set; }
        public string Quote_01_By { get; set; }
        public string Quote_02 { get; set; }
        public string Quote_02_Author { get; set; }
        public string Quote_02_By { get; set; }
        public string Other_Information { get; set; }
        public string Directed_By { get; set; }
        public string Written_By { get; set; }
        public Nullable<DateTimeOffset> CreatedAt { get; set; }
        public Nullable<DateTimeOffset> UpdatedAt { get; set; }
        public string MediaUrl { get; set; }
    }
} 