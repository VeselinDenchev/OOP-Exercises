namespace _02_OOP_Basics_Exams_Minedraft.Harvesters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public abstract class Harverster
    {
        protected string id;
        protected double oreOutput;
        protected double energyRequirement;

        public string Id { get; set; }
        public virtual double OreOutput
        {
            get
            {
                return this.oreOutput;
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

                this.oreOutput = value;
            }
        }
        public virtual double EnergyRequirement
        {
            get
            {
                return this.energyRequirement;
            }
            set
            {
                if (value < 0 || value > 20000)
                {
                    throw new ArgumentOutOfRangeException("Energy requirement must be between 0 and 20000!");
                }

                this.energyRequirement = value;
            }
        }

    }
}
