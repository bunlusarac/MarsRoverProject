using MarsRoverProject.Domain.Enums;

namespace MarsRoverProject.Domain.Exceptions;

public class RoverException : Exception
{
    public string Type { get; set; }
    public string Detail { get; set; }
    public string Title { get; set; }
    public string Instance { get; set; }
    public int Status { get; set; }
    public int ErrorCode { get; set; }
    
    public RoverException(RoverErrorCode error)
    {
        Type = "rover-exception";
        Title = error.ToString();
        Status = 400;
        ErrorCode = (int) error;
        Detail = error.ToDescriptionString();
        Instance = "/api/parse";
    }
}