namespace Domain.Entities;

public class EmployeeEntity
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }

    public int Salary { get; set; }

    public string City { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; }
}