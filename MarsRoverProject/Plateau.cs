using System.Numerics;

namespace MarsRoverProject;

public class Plateau
{
    public Vector2 LowerLeftCornerPos { get; }
    public Vector2 UpperRightCornerPos { get; }
    public List<Rover> Rovers;
    
    public Plateau(Vector2 lowerLeftCornerPos, Vector2 upperRightCornerPos)
    {
        this.LowerLeftCornerPos = lowerLeftCornerPos;
        this.UpperRightCornerPos = upperRightCornerPos;
        this.Rovers = new List<Rover>();
    }
    
    public Plateau(Vector2 upperRightCornerPos)
    {
        this.LowerLeftCornerPos = Vector2.Zero;
        this.UpperRightCornerPos = upperRightCornerPos;
        this.Rovers = new List<Rover>();
    }
    
    public bool PointInPlateau(Vector2 point)
    {
        return ((point.X > this.LowerLeftCornerPos.X && point.Y > this.LowerLeftCornerPos.Y) ||
                (point.X < this.UpperRightCornerPos.X && point.Y < this.UpperRightCornerPos.Y));
    }
}