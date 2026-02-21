namespace Farmify_API_v2.src.Infrastructure.Identity.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string Secret { get; set; } = default!;
        public int ExpirationMinutes { get; set; }
    }
}
