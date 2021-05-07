namespace _05_Exercise_Market_Store.Models
{
    using Exception = Constants.Exception;

    using System;

    public class GoldCard : DiscountCard
    {
        protected decimal turnoverForPreviousMonth;

        public GoldCard()
        {
            
        }

        public override decimal TurnoverForPreviousMonth
        {
            get
            {
                return this.turnoverForPreviousMonth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(Exception.NEGATIVE_TURNOVER_EXCEPTION);
                }

                this.turnoverForPreviousMonth = value;

                this.DiscountRatePercantage = Decimal.ToDouble(turnoverForPreviousMonth / 100);

                if (turnoverForPreviousMonth > 1000)
                {
                    this.DiscountRatePercantage = 10;
                }
            }
        }
    }
}
