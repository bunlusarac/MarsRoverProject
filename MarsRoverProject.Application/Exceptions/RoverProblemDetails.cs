using Microsoft.AspNetCore.Mvc;

namespace MarsRoverProject.Domain.Exceptions;

public class RoverProblemDetails : ProblemDetails
{
    public int ErrorCode { get; set; }
}