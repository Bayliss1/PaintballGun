using System;

namespace PaintballGun
{
    class Program
    {
        static void Main(string[] args)
        {
            // setting values for PaintballGun parameters afterwards
            int numberOfBalls = ReadInt(20, "Change number of balls from");
            int magazineSize = ReadInt(16, "Change magazine size from");

            Console.Write($"Loaded [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);

            static int ReadInt(int previousValue, string prompt)
            {
                Console.Write($"{prompt} [ {previousValue} ]: ");
                string inputValue = Console.ReadLine();
                if (int.TryParse(inputValue, out int chosenValue))
                {
                    Console.WriteLine($" using value  {chosenValue}");
                    return chosenValue;
                }
                else
                {
                    Console.WriteLine($" using default value {previousValue}");
                    return previousValue;
                }
            }

            // PaintballGun game, instance created with values set earlier
            PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);

            while (true)
            {
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded.");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
                Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");

                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                else if (key == '+') gun.Balls += gun.MagazineSize;
                else if (key == 'q') return;
            }
        }
    }
}
