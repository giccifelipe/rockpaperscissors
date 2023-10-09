// See https://aka.ms/new-console-template for more information
using RPS.Game.Helpers;

ConsoleHelper.Write("Welcome to the Rock, Paper, Scissors game! Would you like to extend and use Spock and Scissors in the game? (y/n): ", BreakLine: false);
string extendGame = Console.ReadLine();
extendGame = extendGame ?? "n";

GameHelper.SetExtendOptions(string.Equals(extendGame, "y", StringComparison.OrdinalIgnoreCase));

string computer2Choice = "", userChoice = "", computerChoice = "";

while (true)
{
    userChoice = GameHelper.GetUserChoice();
    computerChoice = GameHelper.GetComputerChoice();

    ConsoleHelper.Write($"You choose: {userChoice}", MessageType.Blue);
    ConsoleHelper.Write($"Computer choose: {computerChoice}", MessageType.Orange);

    if (!string.IsNullOrWhiteSpace(computer2Choice))
        ConsoleHelper.Write($"Second computer choose: {computer2Choice}", MessageType.Orange);

    var (Message, WinnerStatus) = GameHelper.DetermineWinner(userChoice, computerChoice, computer2Choice);
    ConsoleHelper.Write(Message, WinnerStatus == 1 ? MessageType.Success : (WinnerStatus == 0 ? MessageType.Warning : MessageType.Error));

    ConsoleHelper.Write("Would you like to play again? (y/n): ", BreakLine: false);
    string keepPlaying = Console.ReadLine();
    keepPlaying = keepPlaying ?? "n";

    if (!string.Equals(keepPlaying, "y", StringComparison.OrdinalIgnoreCase))
    {
        ConsoleHelper.Write("Thanks for playing!");
        break;
    }

    computer2Choice = userChoice;
}