using MarsRoverProject.Domain.Entities;
using MarsRoverProject.Domain.Enums;
using MarsRoverProject.Domain.Exceptions;

namespace MarsRoverProject.Domain;

using System.Numerics;

public static class SignalInterpreter
{
    // Map signal chars to actual facing directions
    static readonly Dictionary<char, RoverFacingDirection> SignalToFacingDirection =
        new ()
        {
            {'N', RoverFacingDirection.North},
            {'E', RoverFacingDirection.East},
            {'S', RoverFacingDirection.South},
            {'W', RoverFacingDirection.West},
        };

    public static Plateau InterpretPlateauInitialization(string coordString)
    {
        var coordArray = coordString.Split(" ");

        if (coordArray.Length != 2)
        {
            throw new RoverException(RoverErrorCode.InvalidSignal);
        }

        try
        {
            return new Plateau(int.Parse(coordArray[0]), int.Parse(coordArray[1]));
        }
        catch (Exception e)
        {
            throw new RoverException(RoverErrorCode.InvalidSignal);
        }
        
    }
    
    public static Rover InterpretRoverInitialization(string roverPropsString, Plateau plateau)
    {
        var roverPropsArray = roverPropsString.Split(" ");
        
        if (roverPropsArray.Length != 3)
        {
            throw new RoverException(RoverErrorCode.InvalidSignal);
        }
        
        try
        {
            var roverFacingDirection = SignalToFacingDirection[char.Parse(roverPropsArray[2])];
            var rover = new Rover(int.Parse(roverPropsArray[0]), int.Parse(roverPropsArray[1]), roverFacingDirection,
                plateau);
            
            return rover;
        }
        catch (Exception e)
        {
            switch (e)
            {
                case RoverException:
                    throw;
                default:
                    throw new RoverException(RoverErrorCode.InvalidSignal);
            }
        }
    }
}