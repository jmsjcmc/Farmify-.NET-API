namespace Farmify_API_v2.src.Application.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
    public class PhillippineTimeProvider : IDateTimeProvider
    {
        private static readonly TimeZoneInfo PH = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
        public DateTime Now => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, PH);
    }
}
