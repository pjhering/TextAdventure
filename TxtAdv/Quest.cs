using System;
namespace TxtAdv
{
    public abstract class Quest
    {
        internal Quest(string name)
        {
            Name = name;
        }

        public abstract bool Update(Model model);

        public string Name { get; }
    }
}
