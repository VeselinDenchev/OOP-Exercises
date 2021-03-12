namespace _02_OOP_Basics_Exams_Minedraft.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PressureProvider : Provider
    {
        public PressureProvider()
        {

        }
        public PressureProvider(string id)
            : this()
        {
            this.Id = id;
        }
        public PressureProvider(string id, double energyOutput)
            : this(id)
        {
            this.EnergyOutput = energyOutput;
        }

        public override double EnergyOutput {
            get
            {
                return this.EnergyOutput;
            }
            set
            {
                if (value <= 0 || value * 1.5 > 10000)
                {
                    throw new ArgumentOutOfRangeException("Provider energy output must be positive, less than 10000!");
                }

                this.energyOutput = value * 1.5;
            }
        }
    }
}
