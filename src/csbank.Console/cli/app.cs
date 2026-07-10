using System;

namespace CSBank.Application.Cli;

public static class App
{
    public static void Menu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== CSBank System Menu ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create Account");
            Console.WriteLine("3. Exit");
            Console.Write("\nChoice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("\nInvalid input! Please enter a number.");
                Pause();
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nLogin Successfully!");
                    Pause();
                    break;

                case 2:
                    Console.WriteLine("\nAccount Created!");
                    Pause();
                    break;

                case 3:
                    Console.WriteLine("\nExited Program. Thank you for using CSBank!");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("\nInvalid option! Please choose 1, 2, or 3.");
                    Pause();
                    break;
            }
        }
    }

    private static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
