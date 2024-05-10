namespace RecordManagement.Domain.Entities;
public class Education
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string? Degree { get; set; }
    public string? School { get; set; }
    public int YearOfGraduation { get; set; }
}
