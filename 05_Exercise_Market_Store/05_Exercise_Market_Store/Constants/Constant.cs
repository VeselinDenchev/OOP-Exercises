namespace _05_Exercise_Market_Store.Constants
{
    public static class Constant
    {
        public const decimal MIN_TURNOVER = 0;

        public const byte PERCANTAGE_DIVIDER = 100;

        public const decimal BRONZE_CARD_NO_DISCOUNT_MAX_VALUE = 100;
        public const decimal BRONZE_CARD_ONE_PERCENT_DISCOUNT_RATE_MAX_VALUE = 300;
        public const double BRONZE_CARD_NO_DISCOUNT_PERCANTAGE = 0;
        public const double BRONZE_CARD_DISCOUNT_RATE_PERCANTAGE_FOR_TURNOVER_BETWEEN_100_AND_300_DOLLARS = 1;
        public const double BRONZE_CARD_MAX_DISCOUNT_RATE_PERCANTAGE = 2.5;

        public const double SILVER_AND_GOLD_CARDS_INITIAL_DISCOUNT_RATE_PERCANTAGE = 2;

        public const decimal SILVER_CARD_INITIAL_DISCOUNT_RATE_MAX_TURNOVER_VALUE = 300;
        public const double SILVER_CARD_MAX_DISCOUNT_RATE_PERCANTAGE = 3.5;

        public const double GOLD_CARD_MAX_DISCOUNT_RATE_PERCANTAGE = 10;
        public const decimal GOLD_CARD_MAX_TURNOVER_VALUE_WHEN_DISCOUNT_RATE_IS_GROWING = 1000;

        public const string CARD_SUFFIX = "Card";
    }
}
