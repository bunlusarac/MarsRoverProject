using System.Numerics;
namespace MarsRoverProject;

public class Rover
{
    public RoverFacingDirection facingDirection;
    public Vector2 position; //todo access modifiers, setters getters
    private Plateau parentPlateau;

    public Rover(Plateau parentPlateau, Vector2 position, RoverFacingDirection facingDirection)
    {
        this.parentPlateau = parentPlateau;
        this.position = position;
        this.facingDirection = facingDirection;
    }
    
    public Rover(Plateau parentPlateau, RoverFacingDirection facingDirection)
    {
        this.parentPlateau = parentPlateau;
        this.position = Vector2.Zero;
        this.facingDirection = facingDirection;
    }
    
    public void Move(int times = 1)
    {
        var newPos = RoverStateMachine.Move(position, facingDirection, times);
        
        if (!parentPlateau.PointInPlateau(newPos))
        {
            throw new RoverOutOfBoundsException(position, this);
        }
        else
        {
            this.position = newPos;
        }
    }

    public void Rotate(RoverRotationDirection rotationDirection)
    {
        this.facingDirection = RoverStateMachine.Rotate(facingDirection, rotationDirection);
    }

    public override string ToString()
    {
        return $"{this.position.X} {this.position.Y} {this.facingDirection}";
    }
}