using ToyRobot;

namespace ToyRobotTests;

public class RobotCommandTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RobotCommandMoveTest()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.East);
        var done = robot.Command("Move");
        Assert.That(done, Is.True);
    }

    [Test]
    public void RobotCommandLeftTest()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.East);
        var done = robot.Command("Left");
        Assert.That(done, Is.True);
    }

    [Test]
    public void RobotCommandRightTest()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.East);
        var done = robot.Command("Right");
        Assert.That(done, Is.True);
    }

    [Test]
    public void RobotCommandCorrectPlaceTestEast()
    {
        var robot = new Robot();
        var done = robot.Command("Place 1, 2, East");
        Assert.Multiple(() =>
        {
            Assert.That(done, Is.True);
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.East));
        });
    }

    [Test]
    public void RobotCommandCorrectPlaceTestWest()
    {
        var robot = new Robot();
        var done = robot.Command("Place 1, 2, West");
        Assert.Multiple(() =>
        {
            Assert.That(done, Is.True);
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.West));
        });
    }

        [Test]
    public void RobotCommandCorrectPlaceTestNorth()
    {
        var robot = new Robot();
        var done = robot.Command("Place 1, 2, North");
        Assert.Multiple(() =>
        {
            Assert.That(done, Is.True);
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.North));
        });
    }

    [Test]
    public void RobotCommandCorrectPlaceTestSouth()
    {
        var robot = new Robot();
        var done = robot.Command("Place 1, 2, South");
        Assert.Multiple(() =>
        {
            Assert.That(done, Is.True);
            Assert.That(robot.PositionX, Is.EqualTo(1));
            Assert.That(robot.PositionY, Is.EqualTo(2));
            Assert.That(robot.Direction, Is.EqualTo(Face.South));
        });
    }
    
    [Test]
    public void RobotCommandIncorrectPlaceTest()
    {
        var robot = new Robot();
        var done = robot.Command("Place abdc, 2, East");
        Assert.That(done, Is.False);

        done = robot.Command("Place 1, asdfhb, East");
        Assert.That(done, Is.False);
        
        done = robot.Command("Place 1, 2, NorthEast");
        Assert.That(done, Is.False);

        done = robot.Command("Place 1, 2, East");
        Assert.That(done, Is.True);
    }

    [Test]
    public void RobotCommandReportTest()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.East);
        var done = robot.Command("Report");
        Assert.That(done, Is.True);
    }

    [Test]
    public void RobotInCorrectCommandTest()
    {
        var robot = new Robot();
        robot.Place(1, 2, Face.East);
        var done = robot.Command("Shouldn't Work");
        Assert.That(done, Is.False);
    }
}
