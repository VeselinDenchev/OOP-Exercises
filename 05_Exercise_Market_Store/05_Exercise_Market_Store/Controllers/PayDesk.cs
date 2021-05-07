namespace _05_Exercise_Market_Store.Controllers
{
    using Models.Interfaces;

    using System;
    using System.Text;

    public static class PayDesk
    {
        public static string OutputFullData(IDiscountCard discountCard, decimal purchaseValue)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string totalPurchaseValue = OutputPurchaseValue(purchaseValue);

            string discountRate = OutputDiscountRate(discountCard.DiscountRatePercantage);

            decimal discount = CalculateDiscount(purchaseValue, discountCard.DiscountRatePercantage);
            string discountString = $"Discount: ${discount:F2}";

            string total = OutputTotal(purchaseValue, discount);

            stringBuilder.AppendLine(totalPurchaseValue);
            stringBuilder.AppendLine(discountRate);
            stringBuilder.AppendLine(discountString);
            stringBuilder.AppendLine(total);

            string output = stringBuilder.ToString();

            return output;
        }

        public static string OutputPurchaseValue(decimal purchaseValue)
        {
            string purchaseValueString = $"Purchase value: ${purchaseValue:F2}";

            return purchaseValueString;
        }

        public static string OutputDiscountRate(double discountRatePercantage)
        {
            string discountRateString = $"Discount rate: {discountRatePercantage:F1}%";

            return discountRateString;
        }

        public static decimal CalculateDiscount(decimal purchaseValue, double discountRatePercantage)
        {
            decimal discount = purchaseValue * (decimal)discountRatePercantage / 100;

            return discount;
        }

        public static string OutputTotal(decimal purchaseValue, decimal discount)
        {
            decimal total = purchaseValue - discount;
            string totalString = $"Total: ${total:F2}";

            return totalString;
        }
    }
}
