using System.ComponentModel.DataAnnotations;

namespace RecordManagement.Domain.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Sex { get; set; }
    public string? CivilStatus { get; set; }
    public string? Citizenship { get; set; }
    public ContactInfo? ContactInfo { get; set; }
    public EmergencyContact? EmergencyContact { get; set; }
    public List<Education>? Educations { get; set; }
    public List<WorkExperience>? WorkExperiences { get; set; }
    public List<Skill>? Skills { get; set; }
    public List<Reference>? References { get; set; }

}