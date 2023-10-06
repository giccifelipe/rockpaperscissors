using System.Runtime.CompilerServices;

namespace RPS.Game.Helpers
{
    internal static class GameHelper
    {
        public static List<string> DefaultChoices = new() { "Rock", "Paper", "Scissors" };
        public static string[] ExtendedChoices = new[] { "Spock", "Lizard" };
        private static bool _ExtendedVersion = false;

        public static void SetExtendOptions(bool ExtendedVersion)
        {
            _ExtendedVersion = ExtendedVersion;
            if (_ExtendedVersion)
                foreach (string choice in ExtendedChoices) { DefaultChoices.Add(choice); }
        }
        public static string GetUserChoice()
        {
            ConsoleHelper.Write($"Enter your choice: [{string.Join(", ", DefaultChoices)}]: ", BreakLine: false);
            string userChoice = Console.ReadLine();
            while (!DefaultChoices.Any(dc => string.Equals(dc, userChoice, StringComparison.OrdinalIgnoreCase)))
            {
                ConsoleHelper.Write($"Invalid choice. Please choose: [{string.Join(", ", DefaultChoices)}] ", BreakLine: false);
                userChoice = Console.ReadLine();
            }

            return userChoice;
        }

        public static string GetComputerChoice()
        {
            return DefaultChoices[new Random().Next(0, DefaultChoices.Count())];
        }

        public static (string Message, int WinnerStatus) DetermineWinner(string user_choice, string computer_choice)
        {
            user_choice = user_choice.ToLower();
            computer_choice = computer_choice.ToLower();

            if (user_choice == computer_choice)
                return ("It's a tie!", 0);
            else if (
                (
                    !_ExtendedVersion &&
                    (
                        (user_choice == "rock" && computer_choice == "scissors") ||
                        (user_choice == "paper" && computer_choice == "rock") ||
                        (user_choice == "scissors" && computer_choice == "paper")
                    )
                ) ||
                (
                    _ExtendedVersion &&
                    (
                        (user_choice == "rock" && (computer_choice == "scissors" || computer_choice == "lizard")) ||
                        (user_choice == "paper" && (computer_choice == "rock" || computer_choice == "spock")) ||
                        (user_choice == "sciss||s" && (computer_choice == "paper" || computer_choice == "lizard")) ||
                        (user_choice == "spock" && (computer_choice == "rock" || computer_choice == "scissors")) ||
                        (user_choice == "lizard" && (computer_choice == "spock" || computer_choice == "paper"))
                    )
                )
            )
                return ("You win!", 1);
            else
                return ("Compnuter wins!", -1);
        }
    }
}
