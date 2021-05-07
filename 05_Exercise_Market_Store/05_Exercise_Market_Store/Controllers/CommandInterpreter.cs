namespace _05_Exercise_Market_Store.Controllers
{
    using Exception = Constants.Exception;

    using Models.Interfaces;

    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter
    {
        private const string CARD_SUFFIX = "Card";

        public string Read(string inputLine)
        {
            char[] skipChars = ". :$,;".ToCharArray();

            string[] commands = inputLine.Split(skipChars, StringSplitOptions.RemoveEmptyEntries);

            string discountCardType = commands[1] + CARD_SUFFIX;

            string turnoverString = commands[5];
            decimal turnoverValue = Decimal.Parse(turnoverString);

            string purchaseValueString = commands[8];
            decimal purchaseValue = Decimal.Parse(purchaseValueString);

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] cardTypes = assembly.GetTypes();

            Type typeToCreate = cardTypes.FirstOrDefault(type => type.Name == discountCardType);

            bool isNull = typeToCreate == null;

            if (isNull)
            {
                throw new InvalidOperationException(Exception.INVALID_CARD_TYPE_EXCEPTION);
            }

            Object instance = Activator.CreateInstance(typeToCreate);
            IDiscountCard discountCard = (IDiscountCard)instance;

            discountCard.TurnoverForPreviousMonth = turnoverValue;

            string result = PayDesk.OutputFullData(discountCard, purchaseValue);

            return result;
        }
    }
}
