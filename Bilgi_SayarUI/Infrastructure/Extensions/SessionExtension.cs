namespace Bilgi_SayarUI.Infrastructure.Extensions
{
    public class SessionExtension
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionExtension(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void ConfigureHttpContextAccessor()
        {
            // HttpContext.Session kullanımı
            var sessionValue = _httpContextAccessor.HttpContext.Session.GetString("editorId");

            // Daha fazla işlem yapabilirsiniz...
        }
    }
}
