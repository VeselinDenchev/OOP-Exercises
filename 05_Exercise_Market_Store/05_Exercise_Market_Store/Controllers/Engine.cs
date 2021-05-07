namespace _05_Exercise_Market_Store.Controllers
{
    using System;

    public class Engine
    {
        private readonly CommandInterpreter commandInterpreter;

        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                string output = commandInterpreter.Read(inputLine);

                Console.WriteLine(output);
            }
        }
    }
}
