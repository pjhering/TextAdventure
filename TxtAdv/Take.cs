using System;
using System.Collections.Generic;
using System.Text;

namespace TxtAdv
{
    public class Take : Command
    {
        string Command.Execute(Model model, string[] args)
        {
            if(args.Length < 2)
            {
                return "take what?";
            }

            StringBuilder sb = new StringBuilder("you took:\n");
            Player p = model.Player;
            Room r = model.Rooms[p.Location];
            HashSet<Item> taken = new HashSet<Item>();

            for(int i = 1; i < args.Length; i++)
            {
                foreach(Item it in r.Contents)
                {
                    if(it.Name.Equals(args[i]))
                    {
                        taken.Add(it);
                        sb.Append("  ")
                            .Append(it.Name)
                            .Append("\n");
                    }
                }
            }

            if(taken.Count == 0)
            {
                sb.Append("  nothing!\n");
            }

            foreach (Item it in taken)
            {
                r.Contents.Remove(it);
                p.Inventory.Add(it);
            }

            return sb.ToString();
        }
    }
}
