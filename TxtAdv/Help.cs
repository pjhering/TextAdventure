using System;
namespace TxtAdv
{
    public class Help : Command
    {
        string Command.Execute(Model model, string[] args)
        {
            return "sorry, help is not available at this time";
        }
    }
}
