using Newtonsoft.Json;
using static System.Console;
using System.Runtime.Serialization;

namespace TxtAdv
{
    public class Door
    {
        public string Description { get; set; }
        public bool Hidden { get; set; }
        public bool Closed { get; set; }
        public bool Locked { get; set; }
        public string To { get; set; }
        public Key Key { get; set; }

        public override string ToString()
        {
            return this.GetType().ToString() + JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            if (Description == null)
            {
                Description = "door";
            }
        }
    }
}