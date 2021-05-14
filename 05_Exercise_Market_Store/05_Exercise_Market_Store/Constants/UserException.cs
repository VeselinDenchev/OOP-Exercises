namespace _05_Exercise_Market_Store.Constants
{
    using System;

    public abstract class UserException : Exception
    {
        public const string NEGATIVE_TURNOVER_EXCEPTION = "Turnover cannot be negative!";

        public const string INVALID_CARD_TYPE_EXCEPTION = "Invalid card type!";
    }
}
