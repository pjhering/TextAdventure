using Newtonsoft.Json;
using static System.Console;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

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

        public bool HasKeyFor(Door d)
        {
            Key k = d.Key;

            foreach(Item i in Inventory)
            {
                if (i.Name.Equals(k.Name))
                {
                    if (i.Properties.ContainsKey("KeyId"))
                    {
                        string keyid = i.Properties["KeyId"];

                        if (keyid.Equals(k.Id))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}