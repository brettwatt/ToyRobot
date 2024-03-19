using ToyRobot.Commands;

namespace ToyRobot;

public class CommandReader
{
  private string _fileName;
  private const string PLACE_TOKEN = "Place ";
  private const string REPORT_TOKEN = "Report";
  private const string MOVE_TOKEN = "Move";
  private const string LEFT_TOKEN = "Left";
  private const string RIGHT_TOKEN = "Right";

  public CommandReader(string fileName)
  {
    _fileName = fileName;

    if (!File.Exists(_fileName))
    {
      throw new ApplicationException($"File: {_fileName} does not exist");
    }
  }

  public IEnumerable<BaseCommand> GetCommands()
  {
    using (StreamReader sr = new(_fileName))
    {
      string line;

      while ((line = sr.ReadLine()) != null)
      {
        line = line.Trim();

        if (line.StartsWith(PLACE_TOKEN, StringComparison.OrdinalIgnoreCase))
        {
          var placeCommand = ParsePlace(line);
          yield return new PlaceCommand(placeCommand.x, placeCommand.y, placeCommand.direction);
        }
        else if (line.Equals(REPORT_TOKEN, StringComparison.OrdinalIgnoreCase))
        {
          yield return new ReportCommand();
        }
        else if (line.Equals(MOVE_TOKEN, StringComparison.OrdinalIgnoreCase))
        {
          yield return new MoveCommand();
        }
        else if (line.Equals(LEFT_TOKEN, StringComparison.OrdinalIgnoreCase))
        {
          yield return new RotateCommand(RotateType.Left);
        }
        else if (line.Equals(RIGHT_TOKEN, StringComparison.OrdinalIgnoreCase))
        {
          yield return new RotateCommand(RotateType.Right);
        }
      }
    }
  }

  private (int x, int y, Direction direction) ParsePlace(string line)
  {
    int placePos = line.IndexOf(PLACE_TOKEN, StringComparison.OrdinalIgnoreCase);

    string[] placeParams = line.Substring(placePos + PLACE_TOKEN.Length).Split(',');

    if (placeParams.Length != 3)
    {
      throw new ApplicationException($"Invalid number of params in Place command for line: {line}");
    }

    int coordX;

    if (!int.TryParse(placeParams[0], out coordX))
    {
      throw new ApplicationException($"Invalid X coordinate value '{placeParams[0]}' in Place command for line: '{line}'");
    }

    int coordY;

    if (!int.TryParse(placeParams[1], out coordY))
    {
      throw new ApplicationException($"Invalid Y coordinate value '{placeParams[1]}' in Place command for line: '{line}'");
    }

    string directionStr = placeParams[2].Trim().ToUpper();

    Direction direction = directionStr switch
    {
      "NORTH" => Direction.North,
      "SOUTH" => Direction.South,
      "EAST" => Direction.East,
      "WEST" => Direction.West,
      _ => Direction.Unknown
    };

    return (coordX, coordY, direction);
  }

}
