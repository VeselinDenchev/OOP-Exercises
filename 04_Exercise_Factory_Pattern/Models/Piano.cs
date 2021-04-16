using System;
using System.Collections.Generic;
using System.Text;

namespace P03.ExerciseFactoryPattern.Models
{
    public class Piano : Instrument
    {
        private const int REPAIR_AMOUNT = 80;

        protected override int RepairAmount => REPAIR_AMOUNT;
    }
}
