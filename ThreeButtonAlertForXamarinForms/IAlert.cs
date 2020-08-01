using System.Threading.Tasks;

namespace ThreeButtonAlertForXamarinForms
{
    public interface IAlert
    {
        Task<string> Display(string title, string message, string firstButton, string secondButton, string cancel);
    }
}
