﻿namespace HairSalon.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Articul> Articuls { get; set; }
    }
}
