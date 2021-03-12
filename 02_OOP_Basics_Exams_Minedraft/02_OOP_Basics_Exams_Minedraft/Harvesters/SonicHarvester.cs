namespace _02_OOP_Basics_Exams_Minedraft.Harvesters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SonicHarvester : Harverster
    {
        protected int sonicFactor;

        public SonicHarvester()
        {

        }
        public SonicHarvester(string id)
            : this()
        {
            this.Id = id;
        }
        public SonicHarvester(string id, double oreOutput)
            : this(id)
        {
            this.OreOutput = oreOutput;
        }
        public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
            : this(id, oreOutput)
        {
            this.SonicFactor = sonicFactor;
        }

        public override double EnergyRequirement
        {
            get
            {
                return this.EnergyRequirement;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Energy requirement can't be negative!");
                }
                else if (value > 1000000)
                {
                    throw new ArgumentOutOfRangeException("Floating-point numbers can't be bigger than 1000000!");
                }

                this.energyRequirement = value;
            }
        }
        public int SonicFactor
        {
            get
            {
                return this.sonicFactor;
            }
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentException("Sonic factor must be between in the interval [1; 10]!");
                }
                if (energyRequirement / value > 20000)
                {
                    throw new ArgumentOutOfRangeException("Energy requirement mustn't be more than 20000!");
                }

                this.sonicFactor = value;
                this.energyRequirement = this.energyRequirement / value;
            }
        }
    }
}
