namespace _02_OOP_Basics_Exams_Minedraft.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SolarProvider : Provider
    {
        public SolarProvider()
        {

        }
        public SolarProvider(string id)
            : this()
        {
            this.Id = id;
        }
        public SolarProvider(string id, double energyOutput)
            : this(id)
        {
            this.EnergyOutput = energyOutput;
        }
    }
}
