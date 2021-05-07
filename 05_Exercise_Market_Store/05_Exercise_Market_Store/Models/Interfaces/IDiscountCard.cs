
namespace _05_Exercise_Market_Store.Models.Interfaces
{
    public interface IDiscountCard
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public abstract decimal TurnoverForPreviousMonth { get; set; }

        public double DiscountRatePercantage { get; set; }
    }
}
