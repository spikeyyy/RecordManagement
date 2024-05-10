namespace RecordManagement.Domain.Entities;
public class WorkExperience
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string? JobTitle { get; set; }
    public string? Company { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
