using System;
namespace TxtAdv
{
    public class Go : Command
    {
        string Command.Execute(Model model, string[] args)
        {
            if(args.Length == 1)
            {
                return useDirection(model, args[0].ToLower());
            }
            else if(args.Length == 2)
            {
                return useDirection(model, args[1].ToLower());
            }
            else
            {
                return "";
            }
        }

        string useDirection(Model model, string arg)
        {
            switch (arg)
            {
                case "north":
                case "east":
                case "south":
                case "west":
                default:
                    return arg + " is not a direction";
            }
        }
    }
}
