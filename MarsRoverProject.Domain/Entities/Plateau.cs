
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

    public bool ContainsPoint(Vector2 point)
    {
        return point.X >= BottomLeftCornerCoords.X && point.X <= TopRightCornerCoords.X &&
               point.Y >= BottomLeftCornerCoords.Y && point.Y <= TopRightCornerCoords.Y;
    }
    
    public Plateau(string coordString)
    {
        var coordArray = coordString.Split(" ");

        if (coordArray.Length != 2)
        {
            throw new RoverException(RoverErrorCode.InvalidSignal);
        }

        try
        {
            TopRightCornerCoords = new Vector2(int.Parse(coordArray[0]), int.Parse(coordArray[1]));
            BottomLeftCornerCoords = Vector2.Zero;
        }
        catch (Exception e)
        {
            throw new RoverException(RoverErrorCode.InvalidSignal);
        }
    }
}