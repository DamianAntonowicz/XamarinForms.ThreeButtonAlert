using System.Threading.Tasks;
using Android.App;
using ThreeButtonAlertForXamarinForms.Droid;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidAlert))]
namespace ThreeButtonAlertForXamarinForms.Droid
{
    public class AndroidAlert : IAlert
    {
        public Task<string> Display(string title, string message, string firstButton, string secondButton, string cancel)
        {
            var taskCompletionSource = new TaskCompletionSource<string>();
            var alertBuilder = new AlertDialog.Builder(Platform.CurrentActivity);

            alertBuilder.SetTitle(title);
            alertBuilder.SetMessage(message);

            alertBuilder.SetPositiveButton(firstButton, (senderAlert, args) =>
            {
                taskCompletionSource.SetResult(firstButton);
            });

            alertBuilder.SetNegativeButton(secondButton, (senderAlert, args) =>
            {
                taskCompletionSource.SetResult(secondButton);
            });

            alertBuilder.SetNeutralButton(cancel, (senderAlery, args) =>
            {
                taskCompletionSource.SetResult(cancel);
            });

            var alertDialog = alertBuilder.Create();
            alertDialog.Show();

            return taskCompletionSource.Task;
        }
    }
}
