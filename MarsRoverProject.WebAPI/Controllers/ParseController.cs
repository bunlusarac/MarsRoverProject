

using System.Text;
using MarsRoverProject.Application.Dto;
using MarsRoverProject.Domain;
using MarsRoverProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace MarsRoverProject.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParseController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post()
    {
        string body;
        
        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        {
            body = await reader.ReadToEndAsync();
        }

        var lines = body.Split("\r\n");
        var plateau = new Plateau(lines[0]);

        for (int i = 1; i != lines.Length; i += 2)
        {
            var rover = new Rover(lines[i], plateau);
            rover.InterpretSequence(lines[i+1]);
        }

        var plateauDto = new PlateauDto()
        {
            BottomLeftCornerX = (int)plateau.BottomLeftCornerCoords.X,
            BottomLeftCornerY = (int)plateau.BottomLeftCornerCoords.Y,
            TopRightCornerX = (int)plateau.TopRightCornerCoords.X,
            TopRightCornerY = (int)plateau.TopRightCornerCoords.Y,
            Id = plateau.Id,
            Rovers = plateau.Rovers.Select(r => new RoverDto()
            {
                Id = r.Id,
                FacingDirection = r.FacingDirection.GetDisplayName(),
                PlateauId = plateau.Id,
                PositionX = (int)r.Position.X,
                PositionY = (int)r.Position.Y,
            })
        };
        
        return Ok(plateauDto);
    }
}