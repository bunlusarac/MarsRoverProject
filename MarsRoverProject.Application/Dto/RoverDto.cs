namespace MarsRoverProject.Application.Dto;

public class RoverDto
{
    public Guid Id { get; set; }
    public Guid PlateauId { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public string FacingDirection { get; set; }   
}