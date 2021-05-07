namespace _05_Exercise_Market_Store.Models
{
    using Exception = Constants.Exception;

    using System;

    public class SilverCard : DiscountCard
    {
        private decimal turnoverForPreviousMonth;

        public SilverCard()
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

                if (turnoverForPreviousMonth <= 300)
                {
                    this.DiscountRatePercantage = 2;
                }
                else
                {
                    this.DiscountRatePercantage = 3.5;
                }
            }
        }
    }
}
