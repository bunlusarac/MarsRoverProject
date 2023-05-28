using System.Numerics;
using MarsRoverProject.Domain.Entities;
using MarsRoverProject.Domain.Enums;
using MarsRoverProject.Domain.Exceptions;

namespace MarsRoverProject.Test;

public class RoverUnitTests : IDisposable
{
    private Plateau plateau;

    public RoverUnitTests()
    {
        plateau = new Plateau(5, 5, 0, 0);
    }

    public void Dispose()
    {
        plateau = null;
    }

    //Rover creation
    
    [Fact]
    public void RoversCanBeCreatedInBounds()
    {
        var inBoundsRover = new Rover(2, 2, RoverFacingDirection.North, plateau);
        var exception = Record.Exception(() => plateau.AddRover(inBoundsRover));
        Assert.Null(exception);
    }

    [Fact]
    public void CreatingRoverOutOfBoundsThrowsRoverException()
    {
        Assert.Throws<RoverException>(() =>  new Rover(6, 6, RoverFacingDirection.North, plateau));
    }
    
    //Rover movement

    [Fact]
    public void RoverCanMoveOnceTowardsNorth()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.North, plateau);
        plateau.AddRover(rover);
        
        var exception = Record.Exception(() => rover.Move());
        Assert.Null(exception);
        Assert.Equal(new Vector2(2, 3), rover.Position);
    }
    
    [Fact]
    public void RoverCanMoveOnceTowardsSouth()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.South, plateau);
        plateau.AddRover(rover);
        
        var exception = Record.Exception(() => rover.Move());
        Assert.Null(exception);
        Assert.Equal(new Vector2(2, 1), rover.Position);
    }
    
    [Fact]
    public void RoverCanMoveOnceTowardsEast()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.East, plateau);
        plateau.AddRover(rover);
        
        var exception = Record.Exception(() => rover.Move());
        Assert.Null(exception);
        Assert.Equal(new Vector2(3, 2), rover.Position);
    }
    
    [Fact]
    public void RoverCanMoveOnceTowardsWest()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.West, plateau);
        plateau.AddRover(rover);
        
        var exception = Record.Exception(() => rover.Move());
        Assert.Null(exception);
        Assert.Equal(new Vector2(1, 2), rover.Position);
    }
    
    [Fact]
    public void RoverCanMoveMultipleTimesTowardsNorth()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.North, plateau);
        plateau.AddRover(rover);
        
        var exception = Record.Exception(() => rover.Move(2));
        Assert.Null(exception);
        Assert.Equal(new Vector2(2, 4), rover.Position);
    }
    
    [Fact]
    public void RoverCanMoveMultipleTimesTowardsSouth()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.South, plateau);
        plateau.AddRover(rover);
        
        var exception = Record.Exception(() => rover.Move(2));
        Assert.Null(exception);
        Assert.Equal(new Vector2(2, 0), rover.Position);
    }
    
    [Fact]
    public void RoverCanMoveMultipleTimesTowardsEast()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.East, plateau);
        plateau.AddRover(rover);
        
        var exception = Record.Exception(() => rover.Move(2));
        Assert.Null(exception);
        Assert.Equal(new Vector2(4, 2), rover.Position);
    }
    
    [Fact]
    public void MovingRoverOutOfBoundsFromTopBorderThrowsRoverException()
    {
        var rover = new Rover(5, 5, RoverFacingDirection.North, plateau);
        plateau.AddRover(rover);

        Assert.Throws<RoverException>(() => rover.Move(1));
    }

    [Fact]
    public void MovingRoverOutOfBoundsFromRightBorderThrowsRoverException()
    {
        var rover = new Rover(5, 5, RoverFacingDirection.East, plateau);
        plateau.AddRover(rover);

        Assert.Throws<RoverException>(() => rover.Move(1));
    }
    
    [Fact]
    public void MovingRoverOutOfBoundsFromBottomBorderThrowsRoverException()
    {
        var rover = new Rover(0, 0, RoverFacingDirection.South, plateau);
        plateau.AddRover(rover);

        Assert.Throws<RoverException>(() => rover.Move(1));
    }
    
    [Fact]
    public void MovingRoverOutOfBoundsFromLeftBorderThrowsRoverException()
    {
        var rover = new Rover(0, 0, RoverFacingDirection.West, plateau);
        plateau.AddRover(rover);

        Assert.Throws<RoverException>(() => rover.Move(1));
    }
    
    [Fact]
    public void RoverCanMoveMultipleTimesTowardsWest()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.West, plateau);
        plateau.AddRover(rover);
        
        var exception = Record.Exception(() => rover.Move(2));
        Assert.Null(exception);
        Assert.Equal(new Vector2(0, 2), rover.Position);
    }
    
    // Rover rotation 
    
    [Fact]
    public void NorthFacingRoverWillFaceEastWhenRotatedRight()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.North, plateau);
        rover.Rotate(RoverRotationDirection.R);
        Assert.Equal(RoverFacingDirection.East, rover.FacingDirection);
    }
    
    [Fact]
    public void NorthFacingRoverWillFaceWestWhenRotatedLeft()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.North, plateau);
        rover.Rotate(RoverRotationDirection.L);
        Assert.Equal(RoverFacingDirection.West, rover.FacingDirection);
    }
    
    [Fact]
    public void EastFacingRoverWillFaceSouthWhenRotatedRight()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.East, plateau);
        rover.Rotate(RoverRotationDirection.R);
        Assert.Equal(RoverFacingDirection.South, rover.FacingDirection);
    }
    
    [Fact]
    public void EastFacingRoverWillFaceNorthWhenRotatedLeft()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.East, plateau);
        rover.Rotate(RoverRotationDirection.L);
        Assert.Equal(RoverFacingDirection.North, rover.FacingDirection);
    }
    
    [Fact]
    public void SouthFacingRoverWillFaceWestWhenRotatedRight()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.South, plateau);
        rover.Rotate(RoverRotationDirection.R);
        Assert.Equal(RoverFacingDirection.West, rover.FacingDirection);
    }
    
    [Fact]
    public void SouthFacingRoverWillFaceEastWhenRotatedLeft()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.South, plateau);
        rover.Rotate(RoverRotationDirection.L);
        Assert.Equal(RoverFacingDirection.East, rover.FacingDirection);
    }
    
    [Fact]
    public void WestFacingRoverWillFaceNorthWhenRotatedRight()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.West, plateau);
        rover.Rotate(RoverRotationDirection.R);
        Assert.Equal(RoverFacingDirection.North, rover.FacingDirection);
    }
    
    [Fact]
    public void WestFacingRoverWillFaceSouthWhenRotatedLeft()
    {
        var rover = new Rover(2, 2, RoverFacingDirection.West, plateau);
        rover.Rotate(RoverRotationDirection.L);
        Assert.Equal(RoverFacingDirection.South, rover.FacingDirection);
    }
}
