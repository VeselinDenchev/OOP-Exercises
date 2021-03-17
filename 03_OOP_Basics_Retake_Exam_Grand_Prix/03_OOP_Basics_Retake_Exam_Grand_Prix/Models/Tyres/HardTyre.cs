namespace _03_OOP_Basics_Retake_Exam_Grand_Prix.Models.Tyres
{
    using Constants;

    public class HardTyre : Tyre
    {
        public HardTyre(string name, double hardness)
            : base(name, hardness)
        {

        }

        public override void ReduceTyreDegradation()
        {
            base.ReduceTyreDegradation();

            if (this.Degradation < Constant.HARD_TYRE_BLOWING_UP_DEGRADATION)
            {
                this.IsBlown = true;
            }
        }
    }
}
