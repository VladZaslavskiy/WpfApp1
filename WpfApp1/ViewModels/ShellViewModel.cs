using Caliburn.Micro;

namespace WpfApp1.ViewModels
{
    public class ShellViewModel : Screen
    {

        private readonly SimpleContainer container;
        private INavigationService navigationService;
             
        public PageOneViewModel Povm{ get; set; }
        public PageTwoViewModel Ptvm { get; set; }

        public ShellViewModel(PageOneViewModel povm, PageTwoViewModel ptvm, SimpleContainer container)
        {
            Povm = povm;
            Ptvm = ptvm;
            this.container = container;
        }


        //public void LoadPageOne()
        //{
        //    ActivateItemAsync(_povm);
        //}

        //public void LoadPageTwo()
        //{
        //    ActivateItemAsync(_ptvm);
        //}
    }
}
