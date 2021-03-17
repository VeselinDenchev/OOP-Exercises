namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Models.Drivers
{
    using Constants;
    using Models.Cars;

    public class EnduranceDriver : Driver
    {
        public EnduranceDriver(string name, Car car, double speed)
            : base(name, car, speed)
        {
            this.Type = "Endurance";
            this.FuelConsumptionPerKm = Constant.ENDURACE_DRIVER_FUEL_CONSUMPTION_PER_KM;
            this.Speed = speed;
        }
    }
}
