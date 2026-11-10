namespace App.Application.Account.Query.GetAll;

public class GetByIdAccountDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FilePath { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? WorkerId { get; set; }
    public string RoleName { get; set; }

    public int? DeniedCount { get; set; }
    public int? CompletedCount { get; set; }
}
