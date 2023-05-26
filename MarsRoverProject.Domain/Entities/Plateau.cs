
using System.Numerics;
using MarsRoverProject.Domain.Common;
using MarsRoverProject.Domain.Enums;
using MarsRoverProject.Domain.Exceptions;

namespace MarsRoverProject.Domain.Entities;

public class Plateau: BaseEntity, IAggregateRoot
{
    public Vector2 TopRightCornerCoords { get; }
    public Vector2 BottomLeftCornerCoords { get; }

    public ICollection<Rover> Rovers { get; } = new List<Rover>();

    public Plateau(int topRightCornerX, int topRightCornerY, int bottomLeftCornerX, int bottomLeftCornerY)
    {
        if (topRightCornerX <= bottomLeftCornerX || topRightCornerY <= bottomLeftCornerY)
        {
            throw new RoverException(RoverErrorCode.InvalidPlateauDimensions);
        }
        
        TopRightCornerCoords = new (topRightCornerX, topRightCornerY);
        BottomLeftCornerCoords = new (bottomLeftCornerX, bottomLeftCornerY);
    }

    public Plateau(int topRightCornerX, int topRightCornerY)
    {
        TopRightCornerCoords = new (topRightCornerX, topRightCornerY);
        BottomLeftCornerCoords = Vector2.Zero;
    }
    
    public void AddRover(Rover rover)
    {
        Rovers.Add(rover);
    }
    
    public bool ContainsPoint(Vector2 point)
    {
        return point.X >= BottomLeftCornerCoords.X && point.X <= TopRightCornerCoords.X &&
               point.Y >= BottomLeftCornerCoords.Y && point.Y <= TopRightCornerCoords.Y;
    }
}