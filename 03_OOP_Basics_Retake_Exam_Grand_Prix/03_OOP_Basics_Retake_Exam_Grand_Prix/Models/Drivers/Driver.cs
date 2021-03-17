namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Models.Drivers
{
    using Constants;
    using Models.Cars;

    public abstract class Driver
    {
        private string name;
        private double totalTime;
        private Car car;
        private double fuelConsumptionPerKm;
        private double speed;
        private string reasonForDnf;
        private string type;
        private bool didNotFinish;

        protected Driver(string name, Car car, double speed)
        {
            this.type = null;
            this.Name = name;
            this.Car = car;
            this.Speed = speed;
            this.TotalTime = Constant.INITIAL_TOTAL_TIME;
            this.DidNotFinish = false;
            this.ReasonForDnf = null;
        }

        public string Type { get; protected set; }
        public string Name { get; set; }
        public Car Car { get; set; }
        public double Speed { get; set; }
        public double TotalTime { get; set; }
        public double FuelConsumptionPerKm { get; protected set; }
        public bool DidNotFinish { get; set; }
        public string ReasonForDnf { get; set; }

        public void UpdateDriverTotalTime (int trackLength)
        {
            this.TotalTime += 60 / (trackLength / this.Speed);
        }

        public double CalculateFuelConsumptionPerLap(int trackLength) => trackLength * this.FuelConsumptionPerKm;

        public void UpdateDriverSpeed()
        {
            this.Speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        }

        public void CheckIfTyreIsBlown()
        {
            if (this.Car.Tyre.IsBlown)
            {
                this.ReasonForDnf = Constant.TYRE_BLOWING_UP_DEGRADATION_MESSAGE;
            }
        }

        public void CheckIfFuelIsEnough(int trackLength)
        {
            double fuelConsumptionPerLap = CalculateFuelConsumptionPerLap(trackLength);

            if ((this.Car.FuelAmount - fuelConsumptionPerLap) <= 0)
            {
                //this.DidNotFinish = true;
                this.ReasonForDnf = Constant.OUT_OF_FUEL_MESSAGE;
            }
            else
            {
                this.Car.FuelAmount -= fuelConsumptionPerLap;
            }
        }
    }
}
