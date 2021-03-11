namespace _02_OOP_Basics_Exams_Minedraft.Functionality
{
    using Providers;
    using Harvesters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class DraftManager
    {
        SonicHarvester sonicHarvester = new SonicHarvester();
        HammerHarvester hammerHarvester = new HammerHarvester();

        SolarProvider solarProvider = new SolarProvider();
        PressureProvider pressureProvider = new PressureProvider();

        string mode = "Full";

        double initialSonicHarvesterOreOutput;
        double initialSonicHarvesterEnergyRequirement;
        double initialHammerHarvesterOreOutput;
        double initialHammerHarvesterEnergyRequirement;

        double totalSolarProviderEnergyOutput;
        double totalPressureProviderEnergyOutput;
        double totalSonicHarvesterOreOutput;
        double totalSonicHarvesterEnergyRequired;
        double totalHammerHarvesterOreOutput;
        double totalHammerHarvesterEnergyRequired;

        double totalEnergyStored;
        double totalMinedOre;

        public string RegisterHarvester(List<string> arguments)
        {
            if (arguments[0] == "Sonic")
            {
                initialSonicHarvesterOreOutput = double.Parse(arguments[2]);
                initialSonicHarvesterEnergyRequirement = double.Parse(arguments[3]);
            }
            else if (arguments[0] == "Hammer")
            {
                initialHammerHarvesterOreOutput = double.Parse(arguments[2]);
                initialHammerHarvesterEnergyRequirement = double.Parse(arguments[3]);
            }
            else
            {
                return "Harvester is not registered, because of it's type";
            }

            if (mode == "Full")
            {
                RegisterHarvesterInFullMode(arguments);
            }
            else if (mode == "Half")
            {
                RegisterHarvesterInHalfMode(arguments);
            }
            else if (mode == "Energy")
            {
                RegisterHarvesterInEnergyMode(arguments);
            }

            return $"Successfully registered {arguments[0]} Harvester – {arguments[1]}";

        }
        private void RegisterHarvesterInFullMode(List<string> arguments)
        {
            if (arguments[0] == "Sonic")
            {
                sonicHarvester.Id = arguments[1];
                sonicHarvester.OreOutput = double.Parse(arguments[2]);
                sonicHarvester.EnergyRequirement = double.Parse(arguments[3]);
                sonicHarvester.SonicFactor = int.Parse(arguments[4]);
            }
            else if (arguments[0] == "Hammer")
            {
                hammerHarvester.Id = arguments[1];
                hammerHarvester.OreOutput = double.Parse(arguments[2]);
                hammerHarvester.EnergyRequirement = double.Parse(arguments[3]);
            }
        }
        private void RegisterHarvesterInHalfMode(List<string> arguments)
        {
            if (arguments[0] == "Sonic")
            {
                sonicHarvester.Id = arguments[1];
                sonicHarvester.OreOutput = double.Parse(arguments[2]) * 0.5;
                sonicHarvester.EnergyRequirement = double.Parse(arguments[3]) * 0.6;
                sonicHarvester.SonicFactor = int.Parse(arguments[4]);
            }
            else if (arguments[0] == "Hammer")
            {
                hammerHarvester.Id = arguments[1];
                hammerHarvester.OreOutput = double.Parse(arguments[2]) * 0.5;
                hammerHarvester.EnergyRequirement = double.Parse(arguments[3]) * 0.6;
            }
        }
        private void RegisterHarvesterInEnergyMode(List<string> arguments)
        {
            if (arguments[0] == "Sonic")
            {
                sonicHarvester.Id = arguments[1];
                sonicHarvester.OreOutput = 0;
                sonicHarvester.EnergyRequirement = 0;
                sonicHarvester.SonicFactor = int.Parse(arguments[4]);
            }
            else if (arguments[0] == "Hammer")
            {
                hammerHarvester.Id = arguments[1];
                hammerHarvester.OreOutput = 0;
                hammerHarvester.EnergyRequirement = 0;
            }
        }
        public string RegisterProvider(List<string> arguments)
        {
            if (arguments[0] == "Solar")
            {
                solarProvider.Id = arguments[1];
                solarProvider.EnergyOutput = double.Parse(arguments[2]);
            }
            else if (arguments[0] == "Pressure")
            {
                pressureProvider.Id = arguments[1];
                pressureProvider.EnergyOutput = double.Parse(arguments[2]);
            }
            else
            {
                return $"Provider is not registered, because of it's type";
            }

            return $"Successfully registered {arguments[0]} Provider – {arguments[1]}";
        }
        public string Day()
        {
            Console.WriteLine("A day has passsed.");

            double totalEnergyStoredDaily = solarProvider.EnergyOutput + pressureProvider.EnergyOutput + totalEnergyStored;
            double totalEnergyConsumedDaily = sonicHarvester.EnergyRequirement + hammerHarvester.EnergyRequirement;

            if (totalEnergyStoredDaily >= totalEnergyConsumedDaily)
            {
                totalEnergyStoredDaily -= totalEnergyConsumedDaily;
                totalEnergyStored = totalEnergyStoredDaily;

                totalSonicHarvesterEnergyRequired += sonicHarvester.EnergyRequirement;
                totalHammerHarvesterEnergyRequired += hammerHarvester.EnergyRequirement;

                totalSonicHarvesterOreOutput += sonicHarvester.OreOutput;
                totalHammerHarvesterOreOutput += hammerHarvester.OreOutput;
                totalMinedOre += (totalSonicHarvesterOreOutput + totalHammerHarvesterOreOutput);

                return $"Energy Provided: {totalEnergyStored}\nPlumbus Ore Mined: {totalMinedOre}";
            }
            else
            {
                return null;
            }
        }
        public string Mode(List<string> arguments)
        {
            bool isSuccessful = false;

            if (arguments[0] == "Mode Full")
            {
                mode = "Full";

                sonicHarvester.OreOutput = initialSonicHarvesterOreOutput;
                sonicHarvester.EnergyRequirement = initialSonicHarvesterEnergyRequirement;

                hammerHarvester.OreOutput = initialSonicHarvesterOreOutput;
                hammerHarvester.EnergyRequirement = initialSonicHarvesterEnergyRequirement;

                isSuccessful = true;
                
            }
            else if (arguments[0] == "Mode Half")
            {
                mode = "Half";

                sonicHarvester.OreOutput = initialSonicHarvesterOreOutput * 0.5;
                sonicHarvester.EnergyRequirement = initialSonicHarvesterEnergyRequirement * 0.6;

                hammerHarvester.OreOutput = initialHammerHarvesterOreOutput * 0.5;
                hammerHarvester.EnergyRequirement = initialHammerHarvesterEnergyRequirement * 0.6;

                isSuccessful = true;
            }
            else if (arguments[0] == "Mode Energy")
            {
                mode = "Energy";

                sonicHarvester.OreOutput = 0;
                sonicHarvester.EnergyRequirement = 0;

                hammerHarvester.OreOutput = 0;
                hammerHarvester.EnergyRequirement = 0;

                isSuccessful = true;
            }

            if (isSuccessful == true)
            {
                return $"Successfully changed working mode to {mode} Mode";
            }

            return "No such working mode!";
        }
        public string Check(string id)
        {
            string checkResult = string.Empty;

            if (solarProvider.Id == id)
            {
                checkResult = $"Solar Provider - {id}\nEnergy Output: {totalSolarProviderEnergyOutput}";
            }
            else if (pressureProvider.Id == id)
            {
                checkResult = $"Solar Provider - {id}\nEnergy Output: {totalPressureProviderEnergyOutput}";
            }
            else if (sonicHarvester.Id == id)
            {
                checkResult = $"Sonic Harvester – {id}" +
                    $"\nOre Output: {totalSonicHarvesterOreOutput}\nEnergy Requirement: {totalSonicHarvesterEnergyRequired}";
            }
            else if (hammerHarvester.Id == id)
            {
                checkResult = $"Hammer Harvester – {id}" +
                    $"\nOre Output: {totalHammerHarvesterOreOutput}\nEnergy Requirement: {totalHammerHarvesterEnergyRequired}";
            }
            else
            {
                checkResult = $"No element found with id – {id}";
            }

            return checkResult;
        }
        public string ShutDown()
        {
            Console.WriteLine("System Shutdown");

            return $"Total Energy Stored: {totalEnergyStored}\nTotal Mined Plumbus Ore: {totalMinedOre}";
        }

    }
}
