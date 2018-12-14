using System;
using static System.Console;

namespace TxtAdv
{
    public class Quest01 : Quest
    {
        private int count;

        public Quest01(string name):base(name)
        {
            count = 0;
        }

        public override bool Update(Model model)
        {
            count += 1;
            return count > 4;
        }
    }
}
