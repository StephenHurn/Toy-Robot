using ToyRobot;

namespace ToyRobotTests;

public class RobotMoveTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RobotMoveEastSafe()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.East);
        robot.Move();
        Assert.Multiple(() =>
        {
            Assert.That(robot.PositionX, Is.EqualTo(2));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.East));
        });
    }
    
    [Test]
    public void RobotMoveWestSafe()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.West);
        robot.Move();
        Assert.Multiple(() =>
        {
            Assert.That(robot.PositionX, Is.EqualTo(0));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.West));
        });
    }
    
    [Test]
    public void RobotMoveNorthSafe()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.North);
        robot.Move();
        Assert.Multiple(() =>
        {
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(3));
            Assert.That(robot.Direction, Is.EqualTo(Face.North));
        });
    }
    
    [Test]
    public void RobotMoveSouthSafe()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.South);
        robot.Move();
        Assert.Multiple(() =>
        {
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(1));
            Assert.That(robot.Direction, Is.EqualTo(Face.South));
        });
    }

    [Test]
    public void RobotMoveTooFarWest()
    {
        var robot = new Robot();
        robot.Place(0, 2, Face.West);
        robot.Move();
        Assert.Multiple(() =>
        {
            Assert.That(robot.PositionX, Is.EqualTo(0));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.West));
        });
    }

        [Test]
    public void RobotMoveTooFarEast()
    {
        var robot = new Robot();
        robot.Place(4, 2, Face.East);
        robot.Move();
        Assert.Multiple(() =>
        {
            Assert.That(robot.PositionX, Is.EqualTo(4));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.East));
        });
    }

        [Test]
    public void RobotMoveTooFarNorth()
    {
        var robot = new Robot();
        robot.Place(1, 4, Face.North);
        robot.Move();
        Assert.Multiple(() =>
        {
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(4));
            Assert.That(robot.Direction, Is.EqualTo(Face.North));
        });
    }

        [Test]
    public void RobotMoveTooFarSouth()
    {
        var robot = new Robot();
        robot.Place(1, 0, Face.South);
        robot.Move();
        Assert.Multiple(() =>
        {
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(0));
            Assert.That(robot.Direction, Is.EqualTo(Face.South));
        });
    }
}