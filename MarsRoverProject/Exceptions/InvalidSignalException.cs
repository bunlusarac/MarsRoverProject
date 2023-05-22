namespace MarsRoverProject;

public class InvalidSignalException: Exception
{
    public char InvalidSignal { get; }
    
    //todo: constructors
    public InvalidSignalException(char invalidSignal) : base($"{invalidSignal} is not a valid signal.")
    {
        this.InvalidSignal = invalidSignal;
    }
}