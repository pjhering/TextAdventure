using Newtonsoft.Json;
using System;
using static System.Console;
using System.IO;

namespace TxtAdv
{
    class CLI
    {
        public static void Main(string[] args)
        {
            DAL dal = new DAL(args);
            if (dal.FileExits)
            {
                BeginGame(dal.GameFile);
            }
            else
            {
                WriteLine(dal.ErrorMessage);
            }
        }

        private static void BeginGame(Model model)
        {
            GameEngine engine = new GameEngine(model);

            WriteLine("\t" + model.Title);
            WriteLine("\t" + model.Author);
            WriteLine("\t" + model.Preamble);

            while (!model.Quit)
            {
                Write(">");
                string request = ReadLine();
                string response = engine.Handle(request);
                WriteLine(response);
                WriteLine();
            }
        }
    }
}
