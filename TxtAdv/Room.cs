using Newtonsoft.Json;
using static System.Console;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TxtAdv
{
    public class Room
    {
        public string Description { get; set; }
        public HashSet<Item> Contents { get; set; }
        public Door North { get; set; }
        public Door East { get; set; }
        public Door South { get; set; }
        public Door West { get; set; }

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
