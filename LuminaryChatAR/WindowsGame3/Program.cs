using System;

namespace Luminary_Chat_AR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Luminary_Chat_AR.LuminaryChatAR game =new LuminaryChatAR())
            {
                game.Run();
            }
        }
    }
}

