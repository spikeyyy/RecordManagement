namespace RecordManagement.Domain.Entities;
public class Reference
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string? ReferenceName { get; set; }
    public string? Relationship { get; set; }
    public string? ContactInfo { get; set; }
}