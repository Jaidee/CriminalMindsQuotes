using System;
using System.Collections.Generic;

namespace CriminalMindsQuotes
{
    public class EpisodeList
    {
        public string Id { get; set; }
        public string EpisodeId { get; set; }
        public string Title { get; set; }
        public DateTime AirDate { get; set; }
        public string EpisodeKey { get; set; }

        public EpisodeList(string id, string episodeId, string title, DateTime airDate)
        {
            Id = id;
            EpisodeId = string.Format("Episode {0}", episodeId.Substring(4, 2));
            Title = title;
            AirDate = airDate;
            EpisodeKey = string.Format("Season {0}", episodeId.Substring(1, 2));
        }

    }

    public class EpisodeListItem
    {
        public string Id { get; set; }
        public string EpisodeId { get; set; }
        public string Title { get; set; }
        public DateTime AirDate { get; set; }
        public string EpisodeKey { get; set; }  
    }
}
