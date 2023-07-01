using Microsoft.Quantum.Simulation.Simulators;
using QuantumRoulette.Rng;

class Program
{
    static void Main() {
        Random rand = new Random();
        int bankroll = 1000;  // The player starts with $1000
        Console.WriteLine("Welcome to Quantum Roulette! You start with $" + bankroll + ".");

        while (true) {
            Console.Write("Enter the amount of your bet: ");
            string betString = Console.ReadLine()!;
            int bet;
            if (!int.TryParse(betString, out bet) || bet <= 0 || bet > bankroll) {
                Console.WriteLine("Invalid bet. Please enter a positive integer not exceeding your bankroll.");
                continue;
            }

            bankroll -= bet;  // Subtract the bet from the bankroll

            Console.Write("Enter the number you want to bet on (0-36): ");
            string numberString = Console.ReadLine()!;
            int number;
            if (!int.TryParse(numberString, out number) || number < 0 || number > 36) {
                Console.WriteLine("Invalid number. Please enter a number between 0 and 36.");
                bankroll += bet;  // Refund the bet
                continue;
            }

            Console.WriteLine($"Spinning the wheel...");

            long result = -1;
            using (var sim = new QuantumSimulator()) {
                result = QuantumRandomNumber.Run(sim).Result;
            }

            if (result == number) {
                int winnings = bet * 35;
                Console.WriteLine($"The ball landed on {result}. Congratulations, you win {winnings}!");
                bankroll += winnings;  // Add the winnings to the bankroll
            } else {
                Console.WriteLine($"The ball landed on {result}. Sorry, you lose your bet of {bet}.");
            }

            Console.WriteLine("Your current bankroll is $" + bankroll + ".");

            if (bankroll <= 0) {
                Console.WriteLine("You've run out of money. Game over!");
                break;
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string playAgain = Console.ReadLine()!.ToLower();
            if (playAgain != "yes" && playAgain != "y") {
                break;
            }
        }
        Console.WriteLine("Thanks for playing!");
    }
}