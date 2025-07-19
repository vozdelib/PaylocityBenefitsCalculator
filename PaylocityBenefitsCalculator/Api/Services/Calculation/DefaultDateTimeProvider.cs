namespace Api.Services.Calculation
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime Today => DateTime.Today;
    }
}
