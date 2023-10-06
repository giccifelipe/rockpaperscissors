namespace RPS.Game.Helpers;

public static class ConsoleHelper
{
    public static void WriteLine(string message, MessageType messageType = MessageType.Default)
    {
        switch (messageType)
        {
            case MessageType.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case MessageType.Default:
                Console.ResetColor();
                break;
            case MessageType.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case MessageType.Success:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            default:
                WriteLine("meesage type required.", MessageType.Error);
                break;
        }

        Console.WriteLine(message); // <-- This line is still white on blue.
        Console.ResetColor();
    }
    public static void Write(string message, MessageType messageType = MessageType.Default, bool BreakLine = true)
    {
        switch (messageType)
        {
            case MessageType.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case MessageType.Default:
                Console.ResetColor();
                break;
            case MessageType.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case MessageType.Success:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case MessageType.Blue:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case MessageType.Orange:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            default:
                WriteLine("meesage type required.", MessageType.Error);
                break;
        }
        if (BreakLine)
            Console.WriteLine(message);
        else
            Console.Write(message);
        Console.ResetColor();
    }
}

public enum MessageType
{
    Error = -1,
    Default = 0,
    Warning = 1,
    Success = 2,
    Blue = 3,
    Orange = 4,
}