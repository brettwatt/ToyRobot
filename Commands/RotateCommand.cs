namespace ToyRobot.Commands;

public class RotateCommand : BaseCommand
{
    private readonly RotateType _rotateType;

    public RotateCommand(RotateType rotateType) : base(CommandType.Rotate)
    {
        _rotateType = rotateType;
    }

    public RotateType RotateType => _rotateType;
}
