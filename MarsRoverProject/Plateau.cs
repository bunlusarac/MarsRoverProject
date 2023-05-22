using System.Numerics;

namespace MarsRoverProject;

public class Plateau
{
    //todo check access modifiers
    private Vector2 LowerLeftCornerPos { get; }
    private Vector2 UpperRightCornerPos { get; }
    public List<RoverOld> Rovers;

    // Constructors
    public Plateau(Vector2 upperRightCornerPos)
    {
        this.LowerLeftCornerPos = Vector2.Zero;
        this.UpperRightCornerPos = upperRightCornerPos;
        this.Rovers = new List<RoverOld>();
    }

    public Plateau(Vector2 upperRightCornerPos, List<RoverOld> rovers)
    {
        this.LowerLeftCornerPos = Vector2.Zero;
        this.UpperRightCornerPos = upperRightCornerPos;
        this.Rovers = rovers;
    }

    public Plateau(Vector2 upperRightCornerPos, params RoverOld[] rovers)
    {
        this.LowerLeftCornerPos = LowerLeftCornerPos;
        this.UpperRightCornerPos = UpperRightCornerPos;
        this.Rovers = new List<RoverOld>(rovers);
    }

    public Plateau(Vector2 lowerLeftCornerPos, Vector2 upperRightCornerPos)
    {
        this.LowerLeftCornerPos = LowerLeftCornerPos;
        this.UpperRightCornerPos = UpperRightCornerPos;
        this.Rovers = new List<RoverOld>();
    }

    public Plateau(Vector2 lowerLeftCornerPos, Vector2 upperRightCornerPos, List<RoverOld> rovers)
    {
        this.LowerLeftCornerPos = LowerLeftCornerPos;
        this.UpperRightCornerPos = UpperRightCornerPos;
        this.Rovers = rovers;
    }

    public Plateau(Vector2 lowerLeftCornerPos, Vector2 upperRightCornerPos, params RoverOld[] rovers)
    {
        this.LowerLeftCornerPos = LowerLeftCornerPos;
        this.UpperRightCornerPos = UpperRightCornerPos;
        this.Rovers = new List<RoverOld>(rovers);
    }

    public bool PointInPlateau(Vector2 point)
    {
        if ((point.X < this.LowerLeftCornerPos.X && point.Y < this.LowerLeftCornerPos.Y) ||
            (point.X > this.UpperRightCornerPos.X && point.Y > this.UpperRightCornerPos.Y))
        {
            var msg = $"Point {point} is out of bounds of the plateau.";
            throw new RoverOutOfBoundsException(msg);
            return false;
        }
        else
        {
            return true;
        }
    }
}