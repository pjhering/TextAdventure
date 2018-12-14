using Newtonsoft.Json;
using static System.Console;
using System.Runtime.Serialization;

namespace TxtAdv
{
    public class Key
    {
        public string Name { get; set; }
        public string Id { get; set; }

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
