using System.Numerics;

namespace MarsRoverProject;

public static class SignalInterpreter
{
    // Mapping of signals to rotation angles in radians.
    public static IDictionary<char, double> SignalAngles = new Dictionary<char, double>
    {
        { 'L',  Math.PI / 2 },
        { 'R', -Math.PI / 2 },
    };

    public static void InterpretSequence(string sequence, RoverOld roverOld)
    {
        try
        {
            foreach (var signal in sequence)
            {
                InterpretCharacter(signal, roverOld);
            }
        }
        catch (InvalidSignalException e)
        {
            Console.WriteLine($"The signal {e.InvalidSignal} is invalid and could not be interpreted. Terminating...");
            Environment.Exit(1);
        }
    }

    private static void InterpretCharacter(char signal, RoverOld roverOld)
    {
        switch (signal)
        {
            case 'M':
                roverOld.MoveForward();
                break;
            case 'R':
            case 'L':
                roverOld.Rotate(SignalAngles[signal]);
                break;
            default:
                var msg = $"Invalid signal ${signal} could not be interpreted as a rover command.";
                throw new InvalidSignalException(signal, msg);
        }
    }
    
   
}