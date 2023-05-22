using System.Numerics;

namespace MarsRoverProject;

public class RoverOutOfBoundsException : Exception
{
    public Rover rover;
    public Vector2 oobPos;
    public RoverOutOfBoundsException(Vector2 oobPos, Rover rover) : base($"Rover at {rover.position} gone out of bounds at {oobPos}")
    {
        this.rover = rover;
        this.oobPos = oobPos;
    }
}