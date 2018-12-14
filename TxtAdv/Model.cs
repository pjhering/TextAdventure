using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Console;
using System.Runtime.Serialization;

namespace TxtAdv
{
    public class Model
    {
        public Model()
        {
            Quit = false;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Preamble { get; set; }
        public bool Quit { get; internal set; }
        public Dictionary<string, Room> Rooms { get; set; }
        public Player Player { get; set; }

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