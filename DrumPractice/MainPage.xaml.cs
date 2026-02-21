namespace DrumPractice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            if (BlazorWebViewExtensions.CanGoBack(blazorWebView))
            {
                BlazorWebViewExtensions.GoBack(blazorWebView);
                return true;
            }

            return base.OnBackButtonPressed();
        }
    }
}
