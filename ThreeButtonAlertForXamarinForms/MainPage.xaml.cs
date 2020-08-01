using Xamarin.Forms;

namespace ThreeButtonAlertForXamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var alert = DependencyService.Get<IAlert>();
            var result = await alert.Display("Title", "Message", "First Button", "Second button", "Cancel");

            await DisplayAlert("", "clicked on: " + result, "OK");
        }
    }
}
