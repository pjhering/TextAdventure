namespace TxtAdv
{
    public class Quit : Command
    {
        string Command.Execute(Model model, string[] args)
        {
            model.Quit = true;
            return "goodbye";
        }
    }
}