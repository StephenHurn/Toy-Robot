
using ToyRobot;

internal class Program
{
    static void Main(string[] args)
    {
        var robot = new Robot();
        while(true)
        {
            var command = Console.ReadLine();
            if (command != null)
            {
                if (command.Equals("quit", StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }
                robot.Command(command);
            }
        }
    }
}