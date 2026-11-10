namespace App.Application.Reviews.Query.GetAll;

public class GetAllReviewDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ClientId { get; set; }
    public string ClientName { get; set; }
    public int Stars { get; set; }
}