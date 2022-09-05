using System;

namespace PaintballGun
{
    class Program
    {
        static void Main(string[] args)
        {
            PaintballGun gun = new PaintballGun();
            while (true)
            {
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded.");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
                Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");

                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                else if (key == '+') gun.Balls += PaintballGun.MAGAZINE_SIZE;
                else if (key == 'q') return;
            }
        }
    }
}
