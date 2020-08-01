using System.Threading.Tasks;
using ThreeButtonAlertForXamarinForms.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosAlert))]
namespace ThreeButtonAlertForXamarinForms.iOS
{
    public class IosAlert : IAlert
    {
        public Task<string> Display(string title, string message, string firstButton, string secondButton, string cancel)
        {
            var taskCompletionSource = new TaskCompletionSource<string>();
            var alerController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            
            alerController.AddAction(UIAlertAction.Create(firstButton, UIAlertActionStyle.Default, alert =>
            {
                taskCompletionSource.SetResult(firstButton);
            }));

            alerController.AddAction(UIAlertAction.Create(secondButton, UIAlertActionStyle.Default, alert =>
            {
                taskCompletionSource.SetResult(secondButton);
            }));

            alerController.AddAction(UIAlertAction.Create(cancel, UIAlertActionStyle.Cancel, alert =>
            {
                taskCompletionSource.SetResult(cancel);
            }));

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alerController, animated: true, completionHandler: null);

            return taskCompletionSource.Task;
        }
    }
}
