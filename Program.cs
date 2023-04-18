using System;
using System.Threading;

class RouletteGame
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to the Roulette Casino!");
        Console.WriteLine("You have $1000 in your balance.");
        int balance = 1000;
        int betAmount;
        int betNumber;
        int winningNumber;
        int payout = 0;
        bool playAgain = true;
        Random rand = new Random();
        while (balance > 0 && playAgain)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your balance: $" + balance);

            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Write("Place your bet (min $10, max $" + balance + "): $");
                betAmount = Convert.ToInt32(Console.ReadLine());
            } while (betAmount < 10 || betAmount > balance);

            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Console.Write("Choose a number between 0 and 36: ");
                betNumber = Convert.ToInt32(Console.ReadLine());
            } while (betNumber < 0 || betNumber > 36);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The roulette wheel is spinning...");
            int cursorTop = Console.CursorTop;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(0, cursorTop);
                int a = rand.Next(0, 36);
                int b = rand.Next(0, 36);
                int c = rand.Next(0, 36);
                int d = rand.Next(0, 36);
                int e = rand.Next(0, 36);
                int f = rand.Next(0, 36);
                int g = rand.Next(0, 36);
                int h = rand.Next(0, 36);
                Console.WriteLine($"{a}   {b}    {c}");
                Console.WriteLine(" \\  |  /");
                Console.WriteLine($"{h} - +  - {d}");
                Console.WriteLine(" /  |  \\");
                Console.WriteLine($"{g}   {f}   {e}");
                Console.WriteLine("   /|\\   ");
                Console.WriteLine("   |||   ");
                Thread.Sleep(100);
            }
            winningNumber = rand.Next(37);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, cursorTop);
            Console.WriteLine($"{winningNumber}   {winningNumber}    {winningNumber}");
            Console.WriteLine(" \\  |  /");
            Console.WriteLine($"{winningNumber} - +  - {winningNumber}");
            Console.WriteLine(" /  |  \\");
            Console.WriteLine($"{winningNumber}   {winningNumber}   {winningNumber}");
            Console.WriteLine("   /|\\   ");
            Console.WriteLine("   |||   ");

            if (betNumber == winningNumber)
            {
                payout = betAmount * 5;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You won $" + payout + "!");
            }
            else
            {
                balance -= betAmount;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, you lost $" + betAmount + ".");
            }

            balance += payout;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Do you want to play again? (Y/N): ");
            string playAgainStr = Console.ReadLine();
            playAgain = (playAgainStr.ToLower() == "y") ? true : false;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Game over. Your final balance is $" + balance + ".");
        Console.ReadLine();
    }
}