namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public static void Run()
        {
            RaceTower raceTower = new RaceTower();
            
            int lapsNumber = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());
            raceTower.SetTrackInfo(lapsNumber, trackLength);

            while (raceTower.HasEnded == false)
            {
                string input = Console.ReadLine();
                string output = string.Empty;
                List<string> arguments = input.Split(" ").ToList();

                string command = arguments[0];
                arguments = arguments.Skip(1).ToList();

                switch (command)
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(arguments);
                        break;

                    case "Leaderboard":
                        output = raceTower.GetLeaderboard();
                        break;

                    case "CompleteLaps":
                        output = raceTower.CompleteLaps(arguments);
                        break;

                    case "Box":
                        raceTower.DriverBoxes(arguments);
                        break;

                    case "ChangeWeather":
                        raceTower.ChangeWeather(arguments);
                        break;
                    
                    default:
                        break;
                }

                if (output == string.Empty)
                {
                    continue;
                }

                Console.WriteLine(output);
            }
            
        }
    }
}
