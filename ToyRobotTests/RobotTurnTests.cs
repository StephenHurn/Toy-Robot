using ToyRobot;

namespace ToyRobotTests;

public class RobotTurnTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RobotNorthTurnLeftCorrectly()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.North);
        robot.TurnLeft();

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(Face.West));
        });
    }

        [Test]
    public void RobotNorthTurnRightCorrectly()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.North);
        robot.TurnRight();

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(Face.East));
        });
    }

    [Test]
    public void RobotEastTurnLeftCorrectly()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.East);
        robot.TurnLeft();

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(Face.North));
        });
    }

            [Test]
    public void RobotEastTurnRightCorrectly()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.East);
        robot.TurnRight();

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(Face.South));
        });
    }

    [Test]
    public void RobotWestTurnLeftCorrectly()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.West);
        robot.TurnLeft();

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(Face.South));
        });
    }

            [Test]
    public void RobotWestTurnRightCorrectly()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.West);
        robot.TurnRight();

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(Face.North));
        });
    }

    [Test]
    public void RobotSouthTurnLeftCorrectly()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.South);
        robot.TurnLeft();

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(Face.East));
        });
    }

    [Test]
    public void RobotSouthTurnRightCorrectly()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.South);
        robot.TurnRight();

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.Direction, Is.EqualTo(Face.West));
        });
    }

}
