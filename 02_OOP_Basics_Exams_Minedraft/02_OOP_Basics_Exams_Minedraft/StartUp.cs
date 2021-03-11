namespace _02_OOP_Basics_Exams_Minedraft
{
    using Functionality;
    using Harvesters;
    using Providers;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            DraftManager draftManager = new DraftManager();

            List<string> registerHarvesterList1 = new List<string>()
            {
                "Sonic",
                "AS-51",
                "100",
                "100",
                "10",
            };
            Console.WriteLine(draftManager.RegisterHarvester(registerHarvesterList1));

            List<string> registerHarvesterList2 = new List<string>()
            {
                "Hammer",
                "CDD",
                "100",
                "50",
            };
            Console.WriteLine(draftManager.RegisterHarvester(registerHarvesterList2));

            List<string> registerProviderList = new List<string>()
            {
                "Solar",
                "Falcon",
                "100",
            };
            Console.WriteLine(draftManager.RegisterProvider(registerProviderList));

            Console.WriteLine(draftManager.Day());

            Console.WriteLine(draftManager.Check("AS-51"));

            Console.WriteLine(draftManager.Check("CDD"));

            Console.WriteLine(draftManager.Check("Falcon"));

            Console.WriteLine(draftManager.Day());

            Console.WriteLine(draftManager.ShutDown());
        }
    }
}
