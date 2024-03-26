using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace ToyRobot;

public class Robot
{
    private const int MinX = 0;
    private const int MinY = 0;

    private const int MaxX = 4;
    private const int MaxY = 4;

    private const string PlaceCommand = "PLACE";
    private const string MoveCommand = "MOVE";
    private const string LeftCommand = "LEFT";
    private const string RightCommand = "RIGHT";
    private const string ReportCommand = "REPORT";

    public int PositionX {get; private set;}

    public int PositionY {get; private set;}

    public Face Direction {get; private set;}

    public bool IsPlaced { get; private set; } = false;

    /// <summary>
    /// This method takes a string input command and then performs the correct action on the robot.
    /// </summary>
    /// <param name="command">The command string.</param>
    /// <returns>True if the command was successfully parsed, otherwise false.</returns>
    public bool Command(string command)
    {
        command = command.ToUpperInvariant();
        if (command.Trim() == MoveCommand)
        {
            this.Move();
            return true;
        }

        if (command.Trim() == LeftCommand)
        {
            this.TurnLeft();
            return true;
        }

        if (command.Trim() == RightCommand)
        {
            this.TurnRight();
            return true;
        }
        
        if (command.Trim() == ReportCommand)
        {
            this.Report();
            return true;
        }

        if (command.StartsWith(PlaceCommand))
        {
            var parameters = command[(PlaceCommand.Length + 1)..].Split(',');
            if (parameters.Length < 3)
            {
                return false;
            }
            if (!int.TryParse(parameters[0], out int x))
            {
                return false;
            }
            if (!int.TryParse(parameters[1], out int y))
            {
                return false;
            }

            var faceString = parameters[2].Trim();

            if (faceString.Equals(Face.North.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Place(x, y, Face.North);
                return true;
            }

            if (faceString.Equals(Face.South.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Place(x, y, Face.South);
                return true;
            }

            if (faceString.Equals(Face.East.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Place(x, y, Face.East);
                return true;
            }

            if (faceString.Equals(Face.West.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                this.Place(x, y, Face.West);
                return true;
            }

            return false;
        }

        return false;

    }

    public void Place(int positionX, int positionY, Face face)
    {
        if (positionX >= MinX && positionX <= MaxX && positionY >= MinY && positionY <= MaxY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Direction = face;
            this.IsPlaced = true;
            return;
        }

        // it is unspecified whether a failed attempt to place an already placed robot should be placed or not
        // assuming here that an attempt to place a robot that has already been placed is valid
        // and that an invalid placement of an already placed robot makes the robot unplaced.
        this.IsPlaced = false;
    }

    public void Move()
    {
        if (!IsPlaced) { return; }

        var xMove = 0;
        var yMove = 0;
        switch (this.Direction)
        {
            case Face.North:
                if (this.PositionY < MaxY)
                {
                    yMove = 1;
                }
                break;
            case Face.South:
                if (this.PositionY > MinY)
                {
                    yMove = -1;
                }
                break;
            case Face.East:
                if (this.PositionX < MaxX)
                {
                    xMove = 1;
                }
                break;
            case Face.West:
                if (this.PositionX > MinX)
                {
                    xMove = -1;
                }
                break;
            default:
                throw new InvalidOperationException();
        }
        
        this.PositionX += xMove;
        this.PositionY += yMove;
    }

    public void TurnLeft()
    {
        if (!IsPlaced) { return; }

        switch (this.Direction)
        {
            case Face.North:
                this.Direction = Face.West;
                break;
            case Face.South:
                this.Direction = Face.East;
                break;
            case Face.East:
                this.Direction = Face.North;
                break;
            case Face.West:
                this.Direction = Face.South;
                break;
            default:
                throw new InvalidOperationException();
        }

    }

    public void TurnRight()
    {
        if (!IsPlaced) { return; }

        switch (this.Direction)
        {
            case Face.North:
                this.Direction = Face.East;
                break;
            case Face.South:
                this.Direction = Face.West;
                break;
            case Face.East:
                this.Direction = Face.South;
                break;
            case Face.West:
                this.Direction = Face.North;
                break;
            default:
                throw new InvalidOperationException();
        }

    }

    public string Report()
    {
        var output = String.Format("{0},{1},{2}", PositionX, PositionY, Direction);
        Console.WriteLine(output);
        return output;
    }
}
