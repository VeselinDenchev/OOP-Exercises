namespace _05_Exercise_Market_Store.Controllers
{
    using Constants;

    using Models;

    using System;
    using System.Linq;
    using System.Reflection;
    

    public class CommandInterpreter
    {
        public string Read(string inputLine)
        {
            char[] skipChars = ". :$,;".ToCharArray();

            string[] commands = inputLine.Split(skipChars, StringSplitOptions.RemoveEmptyEntries);

            string discountCardType = commands[1] + Constant.CARD_SUFFIX;

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
                throw new InvalidOperationException(UserException.INVALID_CARD_TYPE_EXCEPTION);
            }

            Object instance = Activator.CreateInstance(typeToCreate);
            DiscountCard discountCard = (DiscountCard)instance;

            discountCard.TurnoverForPreviousMonth = turnoverValue;

            string result = PayDesk.OutputFullData(discountCard, purchaseValue);

            return result;
        }
    }
}
