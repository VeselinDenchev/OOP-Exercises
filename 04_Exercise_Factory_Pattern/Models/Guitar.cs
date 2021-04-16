namespace P03.ExerciseFactoryPattern.Models
{
    public class Guitar : Instrument
    {
        private const int REPAIR_AMOUNT = 60;

        protected override int RepairAmount => REPAIR_AMOUNT;
    }
}
