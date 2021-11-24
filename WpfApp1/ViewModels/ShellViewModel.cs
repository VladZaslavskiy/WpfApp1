using Caliburn.Micro;

namespace WpfApp1.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public void LoadPageOne()
        {
            ActivateItemAsync(new PageOneViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItemAsync(new PageTwoViewModel());
        }
    }
}
