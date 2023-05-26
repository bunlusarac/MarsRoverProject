namespace MarsRoverProject.Application.Dto;

public class PlateauDto
{
    public Guid Id { get; set; }
    public int TopRightCornerX { get; set; }
    public int TopRightCornerY { get; set; }
    public int BottomLeftCornerX { get; set; }
    public int BottomLeftCornerY { get; set; }
    public IEnumerable<RoverDto> Rovers { get; set; }
}