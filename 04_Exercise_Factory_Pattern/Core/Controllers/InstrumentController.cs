namespace P03.ExerciseFactoryPattern.Core.Controllers
{
    using System;

    using P03.ExerciseFactoryPattern.Core.Controllers.Interfaces;
    using P03.ExerciseFactoryPattern.Factories;
    using P03.ExerciseFactoryPattern.Models.Interfaces;
    using P03.ExerciseFactoryPattern.Common;

    public class InstrumentController : IController
    {
        private InstrumentFactory instrumentFactory;

        public InstrumentController()
        {
            this.instrumentFactory = new InstrumentFactory();
        }

        public string Create(string type)
        {
            string result = string.Empty;

            try
            {
                IInstrument instrument = this.instrumentFactory.CreateInstrument(type);

                result = instrument.ToString();
            }
            catch
            {
                result = string.Format(ErrorMessages.INVALID_INSTRUMENT, type);
            }

            return result;
        }
    }
}
