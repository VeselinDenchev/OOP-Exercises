namespace _05_Exercise_Market_Store.Models
{
    using Constants;

    using System;

    public class SilverCard : DiscountCard
    {
        private decimal turnoverForPreviousMonth;

        public SilverCard()
            : base()
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
                bool isNegative = value < Constant.MIN_TURNOVER;

                if (isNegative)
                {
                    throw new ArgumentOutOfRangeException(UserException.NEGATIVE_TURNOVER_EXCEPTION);
                }

                this.turnoverForPreviousMonth = value;

                bool isLowerThanThreeHundredDollars 
                    = this.turnoverForPreviousMonth <= Constant.SILVER_CARD_INITIAL_DISCOUNT_RATE_MAX_TURNOVER_VALUE;

                if (isLowerThanThreeHundredDollars)
                {
                    this.DiscountRatePercantage = Constant.SILVER_AND_GOLD_CARDS_INITIAL_DISCOUNT_RATE_PERCANTAGE;
                }
                else
                {
                    this.DiscountRatePercantage = Constant.SILVER_CARD_MAX_DISCOUNT_RATE_PERCANTAGE;
                }
            }
        }
    }
}
