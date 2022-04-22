﻿using SamuraiApp.Domain;

namespace SamuraiApp.Api.DTO
{
    public class SwordElementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Weight { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
    }
}
