namespace App.Domain.Entities
{
    public class Addresses
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string? Address { get; set; }
        public bool isAcrive { get; set; } = false;
        public Guid? ClientId { get; set; }
        public Clients? Client { get; set; }
        public Guid? WorkerId { get; set; }
        public Workers? Workers { get; set; }
        public List<Jobs> Job { get; set; }
    }
}
