using System;

namespace LuminaryFramework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Luminary game = new Luminary())
            {
                game.Run();
            }
        }
    }
}

