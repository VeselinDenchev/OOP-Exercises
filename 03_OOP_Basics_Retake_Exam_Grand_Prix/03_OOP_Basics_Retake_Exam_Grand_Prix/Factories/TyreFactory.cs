namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Factories
{
    using System.Collections.Generic;

    using Models.Tyres;

    public class TyreFactory
    {
        public Tyre Create(List<string> arguments)
        {
            Tyre tyre = null;

            string tyreType = arguments[0];
            double tyreHardness = double.Parse(arguments[1]);

            if (tyreType == "Hard")
            {
                tyre = new HardTyre(tyreType, tyreHardness);
            }
            else if (tyreType == "Ultrasoft")
            {
                double grip = double.Parse(arguments[2]);

                tyre = new UltrasoftTyre(tyreType, tyreHardness, grip);
            }

            return tyre;
        }
    }
}
