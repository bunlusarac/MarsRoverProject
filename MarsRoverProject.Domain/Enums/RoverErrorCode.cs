using System.ComponentModel;

namespace MarsRoverProject.Domain.Enums;

public enum RoverErrorCode
{
    [Description("A rover attempted to go out of bounds of the plateau it belongs to.")]
    OutOfBounds = 100,
    [Description("Attempted to interpret an invalid input.")]
    InvalidSignal = 101,
    [Description("Attempted to initialize a plateau with invalid dimensions.")]
    InvalidPlateauDimensions = 102,
}

public static class RoverErrorCodeExtensions
{
    public static string ToDescriptionString(this RoverErrorCode error)
    {
        DescriptionAttribute[] attributes = (DescriptionAttribute[])error
            .GetType()
            .GetField(error.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
}
