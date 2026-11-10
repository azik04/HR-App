namespace App.Application.Address.Query.GetById;

public class GetByIdAddressDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }
    public string? Address { get; set; }
}
