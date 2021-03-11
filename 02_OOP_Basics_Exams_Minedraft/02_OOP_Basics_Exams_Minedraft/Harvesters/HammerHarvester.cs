namespace _02_OOP_Basics_Exams_Minedraft.Harvesters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class HammerHarvester : Harverster
    {
        public HammerHarvester()
        {

        }
        public HammerHarvester(string id)
            : this()
        {
            this.Id = id;
        }
        public HammerHarvester(string id, double oreOutput, double energyRequirement)
            : this(id)
        {
            this.OreOutput = oreOutput;
            this.EnergyRequirement = energyRequirement;
        }

        public override double OreOutput
        {
            get
            {
                return base.OreOutput;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ore output can't be negative!");
                }
                else if (value > 1000000)
                {
                    throw new ArgumentOutOfRangeException("Floating-point numbers can't be bigger than 1000000!");
                }

                this.oreOutput = value * 3;
            }
        }
        public override double EnergyRequirement
        {
            get
            {
                return base.EnergyRequirement;
            }
            set
            {
                if (value * 2 < 0 || value * 2 > 20000)
                {
                    throw new ArgumentOutOfRangeException("Energy requirement must be between 0 and 20000!");
                }

                this.energyRequirement = value * 2;
            }
        }
    }
}
