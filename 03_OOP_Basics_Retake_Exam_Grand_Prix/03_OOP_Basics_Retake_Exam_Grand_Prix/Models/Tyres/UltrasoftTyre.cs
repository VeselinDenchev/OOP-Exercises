namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Models.Tyres
{
    using Constants;

    public class UltrasoftTyre : Tyre
    {
        public UltrasoftTyre(string name, double hardness, double grip)
            : base(name, hardness)
        {
            this.Grip = grip;
        }

        public override void ReduceTyreDegradation()
        {
            base.ReduceTyreDegradation();

            this.Degradation -= this.Grip;

            if (this.Degradation < Constant.ULTRASOFT_TYRE_BLOWING_UP_DEGRADATION)
            {
                this.IsBlown = true;
            }
        }
    }
}
