namespace ToyRobot;

internal class Program
{
  static void Main(string[] args)
  {
    if (args.Length == 0)
    {
      Console.WriteLine("No Filename found\r\n");
      Console.WriteLine("usage is: ToyRobot mycommands.txt\r\n");
      Environment.Exit(1);
    }

#if DEBUG
    Console.WriteLine($"Running commond file: {args[0]}");
#endif

    CommandReader commandReader = new CommandReader(args[0]);
    var commands = commandReader.GetCommands();

    CommandRunner commandRunner = new CommandRunner(commands);
    commandRunner.RunCommands();
  }
}
