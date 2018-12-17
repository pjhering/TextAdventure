using System;
using System.Collections.Generic;
using System.Text;

namespace TxtAdv
{
    public class Drop : Command
    {
        string Command.Execute(Model model, string[] args)
        {
            if(args.Length < 2)
            {
                return "drop what?";
            }

            StringBuilder sb = new StringBuilder("you dropped:\n");
            HashSet<Item> dropped = new HashSet<Item>();
            Player p = model.Player;
            Room r = model.Rooms[p.Location];

            for(int i = 0; i < args.Length; i++)
            {
                foreach(Item it in p.Inventory)
                {
                    if(it.Name.Equals(args[i]))
                    {
                        dropped.Add(it);
                        sb.Append("  ")
                            .Append(it.Name)
                            .Append("\n");
                    }
                }
            }

            if(dropped.Count == 0)
            {
                sb.Append("  nothing!\n");
            }

            foreach(Item it in dropped)
            {
                p.Inventory.Remove(it);
                r.Contents.Add(it);
            }

            return sb.ToString();
        }
    }
}
