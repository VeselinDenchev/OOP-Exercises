namespace _02_OOP_Basics_Exams_Minedraft.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Provider
    {
        protected string id;
        protected double energyOutput;

        public string Id { get; set; }
        public virtual double EnergyOutput
        {
            get
            {
                return this.energyOutput;
            }
            set
            {
                if (value <= 0 || value >= 10000)
                {
                    throw new ArgumentOutOfRangeException("Provider energy output must be positive, less than 10000!");
                }

                this.energyOutput = value;
            }
        }
    }
}
