namespace TxtAdv
{
    public interface Command
    {
        string Execute(Model model, string[] args);
    }
}