using System.Collections.Generic;
using System.Text;

namespace TxtAdv
{
    public class Look : Command
    {
        string Command.Execute(Model model, string[] args)
        {
            Player p = model.Player;
            Room r = model.Rooms[p.Location];
            StringBuilder sb = new StringBuilder();
            sb.Append("you are in the ")
                .Append(p.Location);

            sb.Append("\nyou see:\n");

            door(r.North, "north", sb);
            door(r.East, "east", sb);
            door(r.South, "south", sb);
            door(r.West, "west", sb);

            if (r.Contents.Count > 0)
            {
                Dictionary<string, int> count = new Dictionary<string, int>();
                foreach (Item i in r.Contents)
                {
                    if(!count.ContainsKey(i.Name))
                    {
                        count.Add(i.Name, 0);
                    }

                    count[i.Name] += 1;
                }

                foreach(KeyValuePair<string, int> kv in count)
                {
                    sb.Append("  ")
                        .Append(kv.Value)
                        .Append(" ")
                        .Append(kv.Key)
                        .Append("\n");
                }
            }

            return sb.ToString();
        }

        private void door(Door d, string dir, StringBuilder sb)
        {
            if(d != null && !d.Hidden)
            {
                sb.Append("  a ")
                    .Append(d.Description)
                    .Append(" to the ")
                    .Append(dir)
                    .Append("\n");
            }
        }
    }
}
