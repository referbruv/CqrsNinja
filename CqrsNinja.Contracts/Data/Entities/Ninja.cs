﻿namespace CqrsNinja.Contracts.Data.Entities
{
    public class Ninja : BaseEntity
    {
        public string Name { get; set; }
        public string Moniker { get; set; }
        public string Bio { get; set; }
        public string Clan { get; set; }
        public string Weapon { get; set; }
    }
}