namespace _05_Exercise_Market_Store.Models
{
    using Constants;

    using System;

    public class BronzeCard : DiscountCard
    {
        private decimal turnoverForPreviousMonth;

        public BronzeCard()
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

                bool isLowerThanNoDiscountMaxValue = turnoverForPreviousMonth < Constant.BRONZE_CARD_NO_DISCOUNT_MAX_VALUE;
                bool isLowerThanOnePercentDiscountRateMaxValue = turnoverForPreviousMonth < Constant.BRONZE_CARD_ONE_PERCENT_DISCOUNT_RATE_MAX_VALUE;

                if (isLowerThanNoDiscountMaxValue)
                {
                    this.DiscountRatePercantage = Constant.BRONZE_CARD_NO_DISCOUNT_PERCANTAGE;
                }
                else if (isLowerThanOnePercentDiscountRateMaxValue)
                {
                    this.DiscountRatePercantage = Constant.BRONZE_CARD_DISCOUNT_RATE_PERCANTAGE_FOR_TURNOVER_BETWEEN_100_AND_300_DOLLARS;
                }
                else
                {
                    this.DiscountRatePercantage = Constant.BRONZE_CARD_MAX_DISCOUNT_RATE_PERCANTAGE;
                }
            }
        }
    }
}
