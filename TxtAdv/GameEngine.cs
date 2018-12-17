using System;
using System.Collections.Generic;

namespace TxtAdv
{
    internal class GameEngine
    {
        private Model model;
        private Dictionary<string, Command> commands;
        private List<Quest> quests;

        public GameEngine(Model model)
        {
            this.model = model;

            Drop drop = new Drop();
            Go go = new Go();
            Hello hello = new Hello();
            Help help = new Help();
            Look look = new Look();
            Quit quit = new Quit();
            Take take = new Take();
            commands = new Dictionary<string, Command>
            {
                { "drop", drop },
                { "go", go },
                { "north", go },
                { "east", go },
                { "south", go },
                { "west", go },
                { "hello", hello },
                { "hi", hello },
                { "?", help },
                { "help", help },
                { "look", look },
                { "quit", quit },
                { "exit", quit },
                { "take", take }
            };

            quests = new List<Quest>
            {
                new Quest01("first quest"),
                new Quest02("second quest")
            };
        }

        public string Handle(string request)
        {
            string response = "";
            request = request.Trim();

            if(request.Length == 0)
            {
                return response;
            }

            String[] args = request.Split(' ');
            string cmd = args[0].ToLower();

            if(commands.ContainsKey(cmd))
            {
                response = commands[cmd].Execute(model, args);

                if(quests.Count > 0)
                {
                    if(quests[0].Update(model))
                    {
                        Quest quest = quests[0];
                        response += "\n" + quest.Name + " completed";
                        quests.RemoveAt(0);

                        if(quests.Count == 0)
                        {
                            response += "\nall quests have been completed";
                        }
                    }
                }
            }
            else
            {
                response = "undefined: " + args[0];
            }

            return response;
        }
    }
}