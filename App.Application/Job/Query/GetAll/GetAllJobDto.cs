namespace App.Application.Job.Query.GetAll;
public class GetAllJobDto
{ 
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public int AddressId { get; set; } 
    public string AdressName { get; set; } 
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } 
    public string AppFile { get; set; }
}

