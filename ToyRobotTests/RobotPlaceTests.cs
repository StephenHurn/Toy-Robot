using ToyRobot;

namespace ToyRobotTests;

public class RobotPlaceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RobotPlacedCorrectly()
    {
        var robot = new Robot();
        Assert.That(robot.IsPlaced, Is.False);

        robot.Place(1, 2, Face.South);

        Assert.Multiple(() =>
        {
            Assert.That(robot.IsPlaced, Is.True);
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.South));
        });
    }

        [Test]
    public void RobotPlacedTooFarWest()
    {
        var robot = new Robot();
        Assert.That(robot.IsPlaced, Is.False);

        robot.Place(-1, 2, Face.South);
        
        Assert.That(robot.IsPlaced, Is.False);
    }

        [Test]
    public void RobotPlacedTooFarEast()
    {
        var robot = new Robot();
        Assert.That(robot.IsPlaced, Is.False);

        robot.Place(5, 2, Face.South);
        
        Assert.That(robot.IsPlaced, Is.False);
    }

        [Test]
    public void RobotPlacedTooFarNorth()
    {
        var robot = new Robot();
        Assert.That(robot.IsPlaced, Is.False);

        robot.Place(1, 5, Face.South);
        
        Assert.That(robot.IsPlaced, Is.False);
    }

        [Test]
    public void RobotPlacedTooFarSouth()
    {
        var robot = new Robot();
        Assert.That(robot.IsPlaced, Is.False);

        robot.Place(1, -1, Face.South);
        
        Assert.That(robot.IsPlaced, Is.False);
    }
}