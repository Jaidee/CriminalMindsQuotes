using System;
namespace CriminalMindsQuotes.Data
{
    public class GuestActor
    {
        public string Id { get; set; } 
        public string EpisodeId { get; set; }
        public string CharacterName { get; set; }
        public string ActorName { get; set; }
        public string ImdbActorLink  { get; set; }
        public Nullable<System.DateTimeOffset> CreatedAt { get; set; } 
        public Nullable<System.DateTimeOffset> UpdatedAt { get; set; } 
        public string GuestType { get; set; }
    }
}
