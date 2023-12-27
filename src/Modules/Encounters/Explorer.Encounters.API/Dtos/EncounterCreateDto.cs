﻿namespace Explorer.Encounters.API.Dtos
{
    public class EncounterCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Radius { get; set; }
        public int XpReward { get; set; }
        public EncounterStatus Status { get; set; }
        public EncounterType Type { get; set; }
    }
    public enum EncounterStatus { Active, Draft, Archived };
    public enum EncounterType { Social, Hidden, Misc, KeyPoint };

}
