namespace ToyRobot.Commands;

public class BaseCommand
{
  private readonly CommandType _commandType;

  protected BaseCommand(CommandType commandType)
  {
    _commandType = commandType;
  }

  public CommandType CommandType => _commandType;
}
