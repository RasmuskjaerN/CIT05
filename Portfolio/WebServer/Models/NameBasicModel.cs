﻿using DataLayer.Domain;

namespace WebServer.Models
{
    public class NameBasicModel
    {
        public string? Url { get; set; }
        public string? PrimaryName { get; set; }
        public string? Birthyear { get; set; }
        public string? Deathyear { get; set; }
        public float? NameRating { get; set; }
        public IList<RoleModel>? Character { get; set; }
    }
    public class RoleModel
    {
        public string? Nconst { get; set; }
        public string? Tconst { get; set; }
        public string? Character { get; set; }

    }
    public class NameCharacterModel
    {
        public string? Tconst { get; set; }
        public string? Character { get; set; }
    }

}
