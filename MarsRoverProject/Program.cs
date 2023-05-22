using System.Numerics;
using System.Text;
using MarsRoverProject;

var fileStream = new FileStream(@"input.txt", FileMode.Open, FileAccess.Read);
var streamReader = new StreamReader(fileStream, Encoding.UTF8);

string line;
Plateau plateau = null;

while ((line = streamReader.ReadLine()) != null)
{
    if(plateau is null)
    {
        plateau = SignalInterpreter.InterpretPlateauInitialization(line);
    }
    else
    {
        var roverPropString = line;
        var roverSignalSequence = streamReader.ReadLine(); //possible null

        var rover = SignalInterpreter.InterpretRoverInitialization(roverPropString, plateau);
        SignalInterpreter.InterpretSequence(roverSignalSequence, rover);
    }
}

foreach (var rover in plateau.Rovers)
{
    Console.WriteLine(rover);
}