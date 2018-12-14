namespace TxtAdv
{
    internal class Hello : Command
    {
        string Command.Execute(Model model, string[] args)
        {
            return "hello";
        }
    }
}