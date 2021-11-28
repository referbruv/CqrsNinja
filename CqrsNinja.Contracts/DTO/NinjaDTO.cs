namespace CqrsNinja.Contracts.DTO
{
    public class NinjaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public string Bio { get; set; }
        public string Clan { get; set; }
        public string Weapon { get; set; }
        public DateTime AddedOn { get; set; }
    }
}