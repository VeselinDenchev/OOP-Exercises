namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Models.Cars
{
    using System;

    using Constants;
    using Models.Tyres;

    public class Car
    {
        private int hp;
        private double fuelAmount;
        private Tyre tyre;

        public Car()
        {

        }
        public Car(int hp, double fuelAmount, Tyre tyre)
            : base()
        {
            this.Hp = hp;
            this.FuelAmount = fuelAmount;
            this.Tyre = tyre;
        }

        public int Hp { get; set; }
        public double FuelAmount 
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                bool isNegative = value < 0;

                if (isNegative)
                {
                    throw new ArgumentOutOfRangeException(Constant.FUEL_AMOUNT_BELOW_ZERO_EXCEPTION);
                }

                if (value > Constant.FUEL_TANK_MAX_CAPACITY)
                {
                    value = Constant.FUEL_TANK_MAX_CAPACITY;
                }

                this.fuelAmount = value;
            } 
        }
        public Tyre Tyre { get; set; }
    }
}
