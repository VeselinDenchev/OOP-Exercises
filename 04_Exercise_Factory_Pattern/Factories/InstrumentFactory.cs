namespace P03.ExerciseFactoryPattern.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using P03.ExerciseFactoryPattern.Common;
    using P03.ExerciseFactoryPattern.Factories.Interfaces;
    using P03.ExerciseFactoryPattern.Models.Interfaces;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            // TODO: write reflection

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();

            Type typeToCreate = types.FirstOrDefault(t => t.Name == type && t.GetInterfaces().Contains(typeof(IInstrument)));

            Object instance = Activator.CreateInstance(typeToCreate);

            IInstrument instrument = (IInstrument)instance;

            return instrument;
        }
    }
}
