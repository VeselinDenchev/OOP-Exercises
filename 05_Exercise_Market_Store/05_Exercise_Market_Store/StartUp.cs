namespace _05_Exercise_Market_Store
{
    using Controllers;

    public class StartUp
    {
        public static void Main()
        {
            CommandInterpreter inputLine = new CommandInterpreter();

            Engine engine = new Engine(inputLine);
            engine.Run();
        }
    }
}
