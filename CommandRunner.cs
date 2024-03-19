using ToyRobot.Commands;

namespace ToyRobot;

public class CommandRunner
{
  private const int COORD_MIN = 0;
  private const int COORD_MAX = 4;
  private readonly IEnumerable<BaseCommand> _commands;

  private int _currentX;
  private int _currentY;
  private Direction _currentFacing;

  private bool _foundValidPlaceCommand = false;

  public CommandRunner(IEnumerable<BaseCommand> commands)
  {
    _commands = commands;
  }

  public void RunCommands()
  {
    foreach (var command in _commands)
    {
      // Ignore all commands until a valid place command
      if (!_foundValidPlaceCommand && command.CommandType != CommandType.Place)
      {
        continue;
      }

      if (command.CommandType == CommandType.Place)
      {
        PlaceCommand placeCommand = command as PlaceCommand;
        ProcessPlaceCommand(placeCommand);

      }
      else if (command.CommandType == CommandType.Rotate)
      {
        RotateCommand rotateCommand = command as RotateCommand;
        ProcessRotateCommand(rotateCommand);
      }
      else if (command.CommandType == CommandType.Move)
      {
        ProcessMoveCommand();
      }
      else if (command.CommandType == CommandType.Report)
      {
        Console.WriteLine($"{_currentX}, {_currentY}, {_currentFacing.ToString()}");
      }
    }
  }

  private void ProcessPlaceCommand(PlaceCommand placeCommand)
  {
    if (placeCommand.X >= COORD_MIN && placeCommand.X <= COORD_MAX &&
        placeCommand.Y >= COORD_MIN && placeCommand.Y <= COORD_MAX &&
        placeCommand.Facing != Direction.Unknown)
    {
      _foundValidPlaceCommand = true;
      _currentX = placeCommand.X;
      _currentY = placeCommand.Y;
      _currentFacing = placeCommand.Facing;

#if DEBUG
      Console.WriteLine($"Place X:{_currentX}, Y:{_currentY}, Facing:{_currentFacing.ToString()}");
#endif
    }
#if DEBUG
    else
    {
      Console.WriteLine($"Invalid Place X:{placeCommand.X}, Y:{placeCommand.Y}, Facing:{placeCommand.Facing.ToString()}");
    }
#endif
  }

  private void ProcessRotateCommand(RotateCommand rotateCommand)
  {
    if (rotateCommand.RotateType == RotateType.Left)
    {
      _currentFacing = (Direction)(((int)_currentFacing + 90) % 360);
    }
    else
    {
      _currentFacing = (Direction)(((int)_currentFacing - 90 + 360) % 360);
    }

#if DEBUG
    Console.WriteLine($"Rotate: {rotateCommand.RotateType.ToString()}, now facing: {_currentFacing.ToString()}");
#endif

    // Alternate solution with simple switch
    //if (rotateCommand.RotateType == RotateType.Left)
    //{
    //  _currentFacing = _currentFacing switch
    //  {
    //    Direction.North => Direction.West,
    //    Direction.West => Direction.South,
    //    Direction.South => Direction.East,
    //    Direction.East => Direction.North
    //  };
    //}
    //else if (rotateCommand.RotateType == RotateType.Right)
    //{
    //  _currentFacing = _currentFacing switch
    //  {
    //    Direction.North => Direction.East,
    //    Direction.East => Direction.South,
    //    Direction.South => Direction.West,
    //    Direction.West => Direction.North
    //  };
    //}


  }

  private void ProcessMoveCommand()
  {
    (int offsetX, int offsetY) moveOffsets = _currentFacing switch
    {
      Direction.North => (0, 1),
      Direction.West => (-1, 0),
      Direction.South => (0, -1),
      Direction.East => (1, 0)
    };

    if (moveOffsets.offsetX != 0)
    {
      if (_currentX + moveOffsets.offsetX < COORD_MIN || _currentX + moveOffsets.offsetX > COORD_MAX)
      {
#if DEBUG
        Console.WriteLine($"Invalid X Move to {_currentX + moveOffsets.offsetX}");
#endif
      }
      else
      {

        _currentX += moveOffsets.offsetX;
#if DEBUG
        Console.WriteLine($"Move to new X: {_currentX}");
#endif
      }
    }

    if (moveOffsets.offsetY != 0)
    {
      if (_currentY + moveOffsets.offsetY < COORD_MIN || _currentY + moveOffsets.offsetY > COORD_MAX)
      {
#if DEBUG
        Console.WriteLine($"Invalid Y Move to {_currentY + moveOffsets.offsetY}");
#endif
      }
      else
      {

        _currentY += moveOffsets.offsetY;
#if DEBUG
        Console.WriteLine($"Move to new Y: {_currentY}");
#endif
      }
    }
  }
}
