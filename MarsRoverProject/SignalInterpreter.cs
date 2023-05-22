using System.Numerics;

namespace MarsRoverProject;

public static class SignalInterpreter
{
    // Map signal chars to actual rotation directions
    static readonly Dictionary<char, RoverRotationDirection> SignalToRotationDirection =
        new Dictionary<char, RoverRotationDirection>()
        {
            {'L', RoverRotationDirection.L},
            {'R', RoverRotationDirection.R}
        };
    
    // Map signal chars to actual facing directions
    static readonly Dictionary<char, RoverFacingDirection> SignalToFacingDirection =
        new Dictionary<char, RoverFacingDirection>()
        {
            {'N', RoverFacingDirection.North},
            {'E', RoverFacingDirection.East},
            {'S', RoverFacingDirection.South},
            {'W', RoverFacingDirection.West},
        };


    public static void InterpretSequence(string sequence, Rover rover)
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
                        rover.Move(times);
                        times = 0;
                    }
                    
                    rover.Rotate(SignalToRotationDirection[signal]);
                    break;
                default:
                    throw new InvalidSignalException(signal);
            }
        }

        if (times != 0)
        {
            rover.Move(times);
        }
    }
    
    public static Plateau InterpretPlateauInitialization(string coordString)
    {
        var coordArray = coordString.Split(" ");
        var coordVec = new Vector2(float.Parse(coordArray[0]), float.Parse(coordArray[1]));

        return new Plateau(coordVec);
    }
    
    public static Rover InterpretRoverInitialization(string roverPropsString, Plateau plateau)
    {
        var roverPropsArray = roverPropsString.Split(" ");
        var roverPositionVector = new Vector2(float.Parse(roverPropsArray[0]), float.Parse(roverPropsArray[1]));
        var roverFacingPosition = SignalToFacingDirection[char.Parse(roverPropsArray[2])];
        var rover = new Rover(plateau, roverPositionVector, roverFacingPosition);
        plateau.Rovers.Add(rover);

        return rover;
    }
}