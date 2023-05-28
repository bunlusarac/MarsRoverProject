using System.Numerics;
using MarsRoverProject.Domain.Entities;
using MarsRoverProject.Domain.Exceptions;

namespace MarsRoverProject.Test;

public class PlateauUnitTests
{
    // Creation
    
    [Fact]
    public void PlateausCanBeCreatedWithSingleBoundaryCorner()
    {
        var exception = Record.Exception(() => new Plateau(5, 5));
        Assert.Null(exception);
    }
    
    [Fact]
    public void PlateausCanBeCreatedWithTwoBoundaryCorners()
    {
        var exception = Record.Exception(() => new Plateau(5, 5, 2, 2));
        Assert.Null(exception);
    }
    
    [Fact]
    public void PlateausCanBeCreatedWithNegativeCorners()
    {
        var exception = Record.Exception(() => new Plateau(5, 5, -5, -5));
        Assert.Null(exception);
    }
    
    [Fact]
    public void CreatingPlateausWithCornersWithInvalidXThrowsRoverException()
    {
        Assert.Throws<RoverException>(() => new Plateau(-5, 2, 5, 2));
    }
    
    [Fact]
    public void CreatingPlateausWithCornersWithInvalidYThrowsRoverException()
    {
        Assert.Throws<RoverException>(() => new Plateau(2, -5, 2, 5));
    }
    
    // Point in boundary method
    
    [Fact]
    public void CallingContainsPointWithPointInsidePlateauReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(3, 3)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOnPlateauBottomBorderReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(3, 2)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOnPlateauTopBorderReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(3, 4)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOnPlateauLeftBorderReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(2, 3)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOnPlateauRightBorderReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(4, 3)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOnTopLeftCornerReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(2, 4)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOnTopRightCornerReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(4, 4)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOnBottomRightCornerReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(4, 2)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOnBottomLeftCornerReturnsTrue()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.True(plateau.ContainsPoint(new Vector2(2, 2)));
    }
    
    [Fact]
    public void CallingContainsPointWithPointOutsidePlateauReturnsFalse()
    {
        var plateau = new Plateau(4, 4, 2, 2);
        Assert.False(plateau.ContainsPoint(new Vector2(5, 5)));
    }
    
    // Signal interpretation
    
    [Fact]
    public void PlateausCanBeConstructedUsingSequences()
    {
        Assert.Equal((new Plateau("4 5")).TopRightCornerCoords, new Plateau(4, 5).TopRightCornerCoords);
    }
    
    [Fact]
    public void ConstructingPlateauWithInvalidSequencesThrowsRoverException()
    {
        Assert.Throws<RoverException>(() => new Plateau("A B"));
    }
    
    [Fact]
    public void ConstructingPlateauWithSequencesWithWhitespaceThrowsRoverException()
    {
        Assert.Throws<RoverException>(() => new Plateau(" 3  4"));
    }
}