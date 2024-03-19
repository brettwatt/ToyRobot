namespace ToyRobot
{
  public enum CommandType { Place, Move, Rotate, Report }
  public enum RotateType { Left, Right }
  public enum Direction : int { North = 90, South = 270, East = 0, West = 180, Unknown = 99999 }
}
