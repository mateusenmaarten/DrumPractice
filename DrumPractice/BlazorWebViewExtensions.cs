using Microsoft.AspNetCore.Components.WebView.Maui;

namespace DrumPractice
{
    public static class BlazorWebViewExtensions
    {
        public static bool CanGoBack(this BlazorWebView? view)
        {
            if (view?.Handler?.PlatformView is null)
                return false;

#if ANDROID
            if (view.Handler.PlatformView is Android.Webkit.WebView androidWebView)
                return androidWebView.CanGoBack();
#elif IOS || MACCATALYST
            if (view.Handler.PlatformView is WebKit.WKWebView wkWebView)
                return wkWebView.CanGoBack;
#endif
            return false;
        }

        public static void GoBack(this BlazorWebView? view)
        {
            if (view?.Handler?.PlatformView is null)
                return;

#if ANDROID
            if (view.Handler.PlatformView is Android.Webkit.WebView androidWebView)
            {
                if (androidWebView.CanGoBack())
                    androidWebView.GoBack();
            }
#elif IOS || MACCATALYST
            if (view.Handler.PlatformView is WebKit.WKWebView wkWebView)
            {
                if (wkWebView.CanGoBack)
                    wkWebView.GoBack();
            }
#endif
        }
    }
}