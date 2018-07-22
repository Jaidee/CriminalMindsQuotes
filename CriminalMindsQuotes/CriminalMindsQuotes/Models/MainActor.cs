using System;

namespace CriminalMindsQuotes
{
    public class MainActor
    {
        public string Id { get; set; }
        public string CharacterName { get; set; } 
        public string WorkTitle { get; set; }
        public string Description { get; set; }
        public string ActorName { get; set; }
        public string ActorDescription { get; set; }
        public DateTime ActorBirthday { get; set; }
        public string ImdbCharLink { get; set; }
        public string ImdbActorLink { get; set; }
        public Nullable<DateTimeOffset> CreatedAt{ get; set; }
        public Nullable<DateTimeOffset> UpdatedAt { get; set; }
        public string CharacterType { get; set; }
        public string ImageUrl { get; set; }
    }
}
