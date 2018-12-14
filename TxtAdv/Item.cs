using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Console;
using System.Runtime.Serialization;

namespace TxtAdv
{
    public class Item
    {
        private static int Count = 0;

        public Item()
        {
            Id = Item.Count++;
        }

        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        public override string ToString()
        {
            return this.GetType().ToString() + JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            //WriteLine(this);
        }
    }
}