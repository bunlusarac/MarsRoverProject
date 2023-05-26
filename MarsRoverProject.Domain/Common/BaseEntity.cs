namespace MarsRoverProject.Domain.Common;

public abstract class BaseEntity 
{
    public Guid Id { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}