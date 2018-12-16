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
            Player p = model.Player;
            Room r = model.Rooms[p.Location];
            Door d = null;

            switch (arg)
            {
                case "north":
                    d = r.North; break;
                case "east":
                    d = r.East; break;
                case "south":
                    d = r.South; break;
                case "west":
                    d = r.West; break;
                default:
                    return arg + " is not a direction";
            }

            if (d == null)
            {
                return "you can't go that way";
            }
            else
            {
                if (d.Closed)
                {
                    if (d.Locked)
                    {
                        if (p.HasKeyFor(d))
                        {
                            p.Location = d.To;
                            return "you are in the " + p.Location;
                        }
                        else
                        {
                            return "you don't have the key";
                        }
                    }
                    else
                    {
                        p.Location = d.To;
                        return "you are in the " + p.Location;
                    }
                }
                else
                {
                    p.Location = d.To;
                    return "you are in the " + p.Location;
                }
            }
        }
    }
}
