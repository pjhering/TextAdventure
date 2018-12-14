using Newtonsoft.Json;
using static System.Console;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace TxtAdv
{
    public class Player
    {
        public string Location { get; set; }
        public HashSet<Item> Inventory { get; set; }

        public override string ToString()
        {
            return this.GetType().ToString() + JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            if(Inventory == null)
            {
                Inventory = new HashSet<Item>();
            }
        }
    }
}