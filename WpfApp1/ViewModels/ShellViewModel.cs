using Caliburn.Micro;
using System;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class ShellViewModel : ModelAny<PersonModel>
    {

        private readonly SimpleContainer container;
        private INavigationService navigationService;

        private PageOneViewModel _povm;
        public PageOneViewModel Povm
        {
            get
            {
                return _povm;
            }
            set
            {
                _povm = value;
                NotifyOfPropertyChange(() => Povm);
            }
        }
        private PageTwoViewModel _ptvm;
        public PageTwoViewModel Ptvm
        {
            get
            {
                return _ptvm;
            }
            set
            {
                _ptvm = value;
                NotifyOfPropertyChange(() => Ptvm);
            }
        }

        public ShellViewModel(PageOneViewModel povm, PageTwoViewModel ptvm, SimpleContainer container)
        {
            _povm = povm ?? throw new ArgumentNullException(nameof(PageOneViewModel));
            _ptvm = ptvm ?? throw new ArgumentNullException(nameof(PageTwoViewModel));
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
