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
            if(args.Length != 1)
            {
                WriteLine("Usage: TxtAdv <model-json-file>");
            }
            else
            {
                FileInfo file = new FileInfo(args[0]);

                if(file.Exists)
                {
                    try
                    {
                        StreamReader reader = file.OpenText();
                        string json = reader.ReadToEnd();
                        Model model = JsonConvert.DeserializeObject<Model>(json);
                        BeginGame(model);
                    }
                    catch (Exception ex)
                    {
                        WriteLine("Error: " + ex.Message);
                    }
                }
                else
                {
                    WriteLine("File Not Found: " + args[0]);
                }
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
