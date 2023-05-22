using System.Numerics;

namespace MarsRoverProject;

public static class RoverStateMachine
{
    // Table of direction states after every rotation 
    private static readonly RoverFacingDirection[][] RotationStateTransitionTable = new[]
    {
        new[] { RoverFacingDirection.West, RoverFacingDirection.East },
        new[] { RoverFacingDirection.North, RoverFacingDirection.South },
        new[] { RoverFacingDirection.East, RoverFacingDirection.West },
        new[] { RoverFacingDirection.South, RoverFacingDirection.North }
    };
    
    // Table of vectors rover will move for every direction state
    private static readonly Vector2[] TranslationVectorTable = new[] 
        { Vector2.UnitY, Vector2.UnitX, -Vector2.UnitY, -Vector2.UnitX } ;
    
    public static RoverFacingDirection Rotate(RoverFacingDirection currentFacingDirection,
        RoverRotationDirection rotationDirection)
    {
        return RotationStateTransitionTable[(int) currentFacingDirection][(int) rotationDirection];
    }

    public static Vector2 Move(Vector2 currentPosition, RoverFacingDirection currentFacingDirection, int times = 1)
    {
        return currentPosition + times * TranslationVectorTable[(int) currentFacingDirection];
    }
}