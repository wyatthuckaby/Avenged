using System;

namespace zork
{
    class Program
    {
        static void Game(ref Player player){
            bool running = true;
            while(running){
                string command = Console.ReadLine();
                running = !player.procCommand(command);
            }
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            Game(ref player);
        }
    }
}
