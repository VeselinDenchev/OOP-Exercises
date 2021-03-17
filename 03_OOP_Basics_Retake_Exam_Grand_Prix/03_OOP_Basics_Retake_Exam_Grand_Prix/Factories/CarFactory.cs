namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Factories
{
    using System.Collections.Generic;

    using Models.Cars;
    using Models.Tyres;

    public class CarFactory
    {
        public Car Create(List<string> arguments)
        {
            Car car = null;
            Tyre tyre = null;
            TyreFactory tyreFactory = new TyreFactory();

            int hp = int.Parse(arguments[0]);
            double fuelAmount = double.Parse(arguments[1]);

            string tyreType = arguments[2];
            string tyreHardness = arguments[3];
            
            List<string> tyreArguments = new List<string>();
            tyreArguments.Add(tyreType);
            tyreArguments.Add(tyreHardness);

            if (tyreType == "Ultrasoft")
            {
                string grip = arguments[4];

                tyreArguments.Add(grip);
            }

            tyre = tyreFactory.Create(tyreArguments);

            car = new Car(hp, fuelAmount, tyre);

            return car;
        }
        
    }
}
