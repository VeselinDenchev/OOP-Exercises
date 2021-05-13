namespace _05_Exercise_Market_Store.Models
{
    using Interfaces;
    using System;

    public abstract class DiscountCard : IDiscountCard
    {
        public DiscountCard()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DiscountCard(string firstName, string lastName, decimal turnoverForPreviousMonth)
            : this()
        {
            this.Id = Guid.NewGuid().ToString();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.TurnoverForPreviousMonth = turnoverForPreviousMonth;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual decimal TurnoverForPreviousMonth { get; set; }

        public double DiscountRatePercantage { get; set; }
    }
}
