using Shyjus.BrowserDetection;

namespace dotnet_7.Middleware
{
    public class Middleware
    {
        private RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IBrowserDetector detector)
        {
            Shyjus.BrowserDetection.IBrowser browser = detector.Browser;

            if (browser.Name == BrowserNames.Edge || browser.Name == BrowserNames.EdgeChromium || browser.Name == BrowserNames.InternetExplorer)
            {
                //await context.Response.WriteAsync("Przegladarki Edge, EdgeChromium oraz IE nie są obsługiwane");
                context.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            }
            await _next.Invoke(context);
        }
    }
}
