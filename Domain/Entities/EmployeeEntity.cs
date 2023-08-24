namespace Domain.Entities;


/// <summary>
/// This class entity is system entity please do not change without the permission of project manager.
/// </summary>
public class EmployeeEntity
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public int Salary { get; set; }

    public string City { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; }
}