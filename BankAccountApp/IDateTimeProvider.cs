namespace BankAccountApp
{
    public interface IDateTimeProvider
    {
        public string FormattedCurrentDate { get; }
    }
}