namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Factories
{
    using System.Collections.Generic;

    using Constants;
    using Models.Cars;
    using Models.Drivers;

    public class DriverFactory
    {
        public Driver Create(List<string> arguments)
        {
            Driver driver = null;
            Car car = null;
            CarFactory carFactory = new CarFactory();

            string driverType = arguments[0];
            string driverName = arguments[1];
            string hpString = arguments[2];
            string fuelAmountString = arguments[3];
            string tyreType = arguments[4];
            string tyreHardness = arguments[5];

            List<string> carAndTyreArguments = new List<string>();
            carAndTyreArguments.Add(hpString);
            carAndTyreArguments.Add(fuelAmountString);
            carAndTyreArguments.Add(tyreType);
            carAndTyreArguments.Add(tyreHardness);

            if (tyreType == "Ultrasoft")
            {
                string grip = arguments[6];
                carAndTyreArguments.Add(grip);
            }

            car = carFactory.Create(carAndTyreArguments);

            int hp = int.Parse(hpString);
            double fuelAmount = double.Parse(fuelAmountString);
            double speed = (hp + Constant.TYRE_DEGRADATION_STARTING_POINTS) / fuelAmount;

            if (driverType == "Aggressive")
            {
                driver = new AggressiveDriver(driverName, car, speed);
            }
            else if (driverType == "Endurance")
            {
                driver = new EnduranceDriver(driverName, car, speed);
            }

            return driver;
        }
    }
}
