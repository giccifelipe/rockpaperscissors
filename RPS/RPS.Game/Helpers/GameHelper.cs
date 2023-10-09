using System.ComponentModel.Design;

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

        public static (string Message, int WinnerStatus) DetermineWinner(string user_choice, string pc1_choice, string pc2_choice = "")
        {
            user_choice = user_choice.ToLower();
            pc1_choice = pc1_choice.ToLower();
            pc2_choice = pc2_choice.ToLower();

            // Check for a tie when all three choices are the same
            if (user_choice == pc1_choice && (string.IsNullOrEmpty(pc2_choice) || (!string.IsNullOrEmpty(pc2_choice) && pc1_choice == pc2_choice)))
                return ("It's a tie!", 0);

            int userResult = CheckWin(user_choice, pc1_choice, pc2_choice);
            int player2Result = CheckWin(pc1_choice, pc2_choice, user_choice);

            // Check for a tie when each player wins over the others
            if (!string.IsNullOrWhiteSpace(pc2_choice))
            {
                int player3Result = CheckWin(pc2_choice, user_choice, pc1_choice);
                if (userResult == 1 && player2Result == 1 && player3Result == -1)
                    return ("It's a tie!", 0);
            }

            // Check if any player has won
            if (userResult == 1 && player2Result == 0 && player2Result == 0)
            {
                return ("You win!", 1);
            }
            else if (player2Result == 1 && userResult == 0 && player2Result == 0)
            {
                return ("Computer wins!", 2);
            }
            else if (userResult == 1 && player2Result == 1 && player2Result == 0)
            {
                return ("You and Computer wins!", 3);
            }
            else if (userResult == 1 && player2Result == 0 && player2Result == 1)
            {
                return ("You and Second computer wins!", 3);
            }
            else if (userResult == 0 && player2Result == 1 && player2Result == 1)
            {
                return ("Computer and Second Computer wins!", 3);
            }
            else
            {
                return ("Second computer wins!", 3);
            }
        }

        // Helper function to check for win/loss
        private static int CheckWin(string user_choice, string pc1_choice, string pc2_choice = "")
        {
            if (
                (!_ExtendedVersion &&
                (
                    (user_choice == "rock" && pc1_choice == "scissors") ||
                    (user_choice == "paper" && pc1_choice == "rock") ||
                    (user_choice == "scissors" && pc1_choice == "paper")
                )) ||
                (_ExtendedVersion &&
                (
                    (user_choice == "rock" && (pc1_choice == "scissors" || pc1_choice == "lizard")) ||
                    (user_choice == "paper" && (pc1_choice == "rock" || pc1_choice == "spock")) ||
                    (user_choice == "scissors" && (pc1_choice == "paper" || pc1_choice == "lizard")) ||
                    (user_choice == "spock" && (pc1_choice == "rock" || pc1_choice == "scissors")) ||
                    (user_choice == "lizard" && (pc1_choice == "spock" || pc1_choice == "paper"))
                )))
            {
                return 1; // Win
            }
            else if ((!string.IsNullOrEmpty(pc2_choice)) && (
                (!_ExtendedVersion &&
                (
                    (user_choice == "rock" && pc2_choice == "scissors") ||
                    (user_choice == "paper" && pc2_choice == "rock") ||
                    (user_choice == "scissors" && pc2_choice == "paper")
                )) ||
                (_ExtendedVersion &&
                (
                    (user_choice == "rock" && (pc2_choice == "scissors" || pc2_choice == "lizard")) ||
                    (user_choice == "paper" && (pc2_choice == "rock" || pc2_choice == "spock")) ||
                    (user_choice == "scissors" && (pc2_choice == "paper" || pc2_choice == "lizard")) ||
                    (user_choice == "spock" && (pc2_choice == "rock" || pc2_choice == "scissors")) ||
                    (user_choice == "lizard" && (pc2_choice == "spock" || pc2_choice == "paper"))
                ))))
            {
                return -1; // Loss
            }
            else if (string.IsNullOrEmpty(pc2_choice))
                return -1; // Loss
            else
            {
                return 0; // Tie
            }
        }
    }
}
