namespace _05_Exercise_Market_Store.Models
{
    using Constants;

    using System;

    public class GoldCard : DiscountCard
    {
        protected decimal turnoverForPreviousMonth;

        public GoldCard()
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

                this.DiscountRatePercantage = Decimal.ToDouble(turnoverForPreviousMonth / Constant.PERCANTAGE_DIVIDER);

                bool isLowerThanTwoPercent = this.DiscountRatePercantage < Constant.GOLD_CARD_INITIAL_DISCOUNT_RATE_PERCANTAGE;
                bool isBiggerThanMaxTurnoverValueWhenDiscountRateIsGrowing 
                    = turnoverForPreviousMonth > Constant.GOLD_CARD_MAX_TURNOVER_VALUE_WHEN_DISCOUNT_RATE_IS_GROWING;

                if (isLowerThanTwoPercent)
                {
                    this.DiscountRatePercantage = Constant.GOLD_CARD_INITIAL_DISCOUNT_RATE_PERCANTAGE;
                }
                else if (isBiggerThanMaxTurnoverValueWhenDiscountRateIsGrowing)
                {
                    this.DiscountRatePercantage = Constant.GOLD_CARD_MAX_DISCOUNT_RATE_PERCANTAGE;
                }
            }
        }
    }
}
