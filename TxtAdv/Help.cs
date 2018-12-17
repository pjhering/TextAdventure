using System;
using System.Collections.Generic;
using System.Text;

namespace TxtAdv
{
    public class Help : Command
    {
        private Dictionary<string, string> terms;

        public Help()
        {
            terms = new Dictionary<string, string>
            {
                {"?", "provides help for a command"},
                {"drop", "drops one or more items in the current room"},
                {"east", "moves the player to the room to the east if possible"},
                {"exit", "exits the game"},
                {"go", "moves the player to the room in the specified direction if possible"},
                {"hello", "says hello to you"},
                {"help", "provides help for a command"},
                {"hi", "says hello to you"},
                {"look", "gives a description of the current room"},
                {"north", "moves the player to the room to the north if possible"},
                {"quit", "exits the game"},
                {"south", "moves the player to the room to the south if possible"},
                {"take", "takes an item from the current room and puts it in your inventory"},
                {"west", "moves the player to the room to the west if possible"}
            };
        }

        string Command.Execute(Model model, string[] args)
        {
            if(args.Length < 2)
            {
                return "help what?";
            }

            if(terms.ContainsKey(args[1]))
            {
                return terms[args[1]];
            }

            return "no help for " + args[1];
        }
    }
}
