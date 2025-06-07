namespace Caneko.Domain.Entities
{
    public class Lot
    {
        public string? Id { get; set; }
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
