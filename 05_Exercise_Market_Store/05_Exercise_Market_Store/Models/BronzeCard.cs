namespace _05_Exercise_Market_Store.Models
{
    using Exception = Constants.Exception;

    using System;

    public class BronzeCard : DiscountCard
    {
        private decimal turnoverForPreviousMonth;

        public BronzeCard()
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

                if (turnoverForPreviousMonth < 100)
                {
                    this.DiscountRatePercantage = 0;
                }
                else if (turnoverForPreviousMonth < 300)
                {
                    this.DiscountRatePercantage = 1;
                }
                else
                {
                    this.DiscountRatePercantage = 2.5;
                }
            }
        }
    }
}
