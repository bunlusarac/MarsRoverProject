
using System.Numerics;
using MarsRoverProject.Domain.Common;
using MarsRoverProject.Domain.Enums;
using MarsRoverProject.Domain.Exceptions;

namespace MarsRoverProject.Domain.Entities;

public class Rover : BaseEntity
{
    private static readonly RoverFacingDirection[][] RotationStateTransitionTable = 
    {
        new[] { RoverFacingDirection.West, RoverFacingDirection.East },
        new[] { RoverFacingDirection.North, RoverFacingDirection.South },
        new[] { RoverFacingDirection.East, RoverFacingDirection.West },
        new[] { RoverFacingDirection.South, RoverFacingDirection.North }
    };
    
    static readonly Dictionary<char, RoverRotationDirection> SignalToRotationDirection =
        new ()
        {
            {'L', RoverRotationDirection.L},
            {'R', RoverRotationDirection.R}
        };
    
    private static readonly Vector2[] TranslationVectorTable = 
        { Vector2.UnitY, Vector2.UnitX, -Vector2.UnitY, -Vector2.UnitX } ;

    public RoverFacingDirection FacingDirection { get; private set; }

    public Vector2 Position { get; private set; }
    
    public Plateau Plateau { get; }
    
    public Rover(int positionX, int positionY, RoverFacingDirection facingDirection, Plateau plateau)
    {
        Vector2 position = new(positionX, positionY);
        
        if (plateau.ContainsPoint(position))
        {
            FacingDirection = facingDirection;
            Position = position;
            Plateau = plateau;
        }
        else
        {
            throw new RoverException(RoverErrorCode.OutOfBounds);
        }
    }
    
    public void Move(int times = 1)
    {
        var newPos = Position + times * TranslationVectorTable[(int) FacingDirection];

        if (Plateau.ContainsPoint(newPos))
        {
            Position = newPos;
        }
        else
        {
            throw new RoverException(RoverErrorCode.OutOfBounds);
        }
    }

    public void Rotate(RoverRotationDirection rotationDirection)
    {
        FacingDirection = RotationStateTransitionTable[(int) FacingDirection][(int) rotationDirection];
    }
    
    public void InterpretSequence(string sequence)
    {
        var times = 0;
        
        foreach (var signal in sequence)
        {
            switch (signal)
            {
                case 'M':
                    ++times;
                    break;
                case 'L':
                case 'R':
                    // Perform movements in batches for scalar vector addition
                    if (times != 0)
                    {
                        Move(times);
                        times = 0;
                    }
                    
                    Rotate(SignalToRotationDirection[signal]);
                    break;
                default:
                    throw new RoverException(RoverErrorCode.InvalidSignal);
            }
        }

        if (times != 0)
        {
            Move(times);
        }
    }
}