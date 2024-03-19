namespace ToyRobot.Commands;

public class PlaceCommand : BaseCommand
{
    private int _x;
    private int _y;
    private Direction _facing;

    public PlaceCommand(int x, int y, Direction facing) : base(CommandType.Place)
    {
        _x = x;
        _y = y;
        _facing = facing;
    }

    public int X { get => _x; set => _x = value; }
    public int Y { get => _y; set => _y = value; }
    public Direction Facing { get => _facing; set => _facing = value; }
}
