namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Models.Tyres
{
    using System;

    using Constants;

    public abstract class Tyre
    {
        private string name;
        private double hardness;
        private double degradation;
        private double grip;
        private bool isBlown;

        public Tyre(string name, double hardness)
        {
            this.Name = name;
            this.Hardness = hardness;
            this.Degradation = Constant.TYRE_DEGRADATION_STARTING_POINTS;
        }

        public string Name { get; set; }
        public double Hardness { get; set; }
        public virtual double Degradation { get; set; }
        public double Grip
        {
            get
            {
                return this.grip;
            }
            set
            {
                bool isPositive = value > 0;

                if (!isPositive)
                {
                    throw new ArgumentOutOfRangeException(Constant.GRIP_NOT_POSITIVE_EXCEPTION);
                }
            }
        }

        public bool IsBlown { get; set; }

        public virtual void ReduceTyreDegradation()
        {
            this.Degradation -= this.Hardness;
        }
    }
}
