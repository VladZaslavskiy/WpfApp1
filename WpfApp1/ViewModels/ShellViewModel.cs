using Caliburn.Micro;
using System;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class ShellViewModel : Screen
    {

        private readonly SimpleContainer container;
       // private INavigationService navigationService;

        private PersonViewModel _povm;
        public PersonViewModel Povm
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

        private OutputViewModel _outVM;

        public OutputViewModel OutVM
        {
            get { return _outVM; }
            set { _outVM = value; }
        }


        public ShellViewModel(OutputViewModel outVM, PageTwoViewModel ptvm, SimpleContainer container)
        {
            //_povm = povm ?? throw new ArgumentNullException(nameof(PersonViewModel));
            _outVM = outVM ?? throw new ArgumentNullException(nameof(OutputViewModel));
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
