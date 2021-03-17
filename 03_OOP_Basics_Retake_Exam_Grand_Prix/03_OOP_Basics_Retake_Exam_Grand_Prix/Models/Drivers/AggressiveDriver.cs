namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Models.Drivers
{
    using Constants;
    using Models.Cars;

    public class AggressiveDriver : Driver
    {
        public AggressiveDriver(string name, Car car, double speed)
            : base( name, car, speed)
        {
            this.Type = "Aggressive";
            this.FuelConsumptionPerKm = Constant.AGGRESIVE_DRIVER_FUEL_CONSUMPTION_PER_KM;
            this.Speed *= Constant.AGGRESIVE_DRIVER_SPEED_MULTIPLIER;
        }
    }
}
