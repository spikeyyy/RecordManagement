namespace RecordManagement.Domain.Entities;
public class Skill
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string? Description { get; set; }
}