using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using WpfApp1.Models;
using Xceed.Wpf.Toolkit;

namespace WpfApp1.ViewModels
{        
    public class PersonViewModel : ModelAny<PersonModel>
    {
        private readonly ICanSaveService _txtService;
        private readonly PersonModel _personModel;
      
        public PersonViewModel(PersonModel model, ICanSaveService txtService) : base(model)
        {
            _txtService = txtService;
            _personModel = model;
          
            AddValidation("Salary", _ => _.Salary > 100 ? "Salary is too big" : string.Empty);
            AddValidation("Salary", _ => _.Salary > 1000 ? "It is realy too big!" : string.Empty);
            AddValidation("Salary", _ => _.Salary < 0 ? "Salary is too small" : string.Empty);
            AddValidation("FirstName", _ => (_.FirstName?.Length).GetValueOrDefault() < 4 
                                                ? "Must be more then 3 chars" : string.Empty);
            AddValidation("LastName", _ => (_.LastName?.Length).GetValueOrDefault() < 4
                                               ? "Must be more then 3 chars" : string.Empty);

            model.PropertyChanged += (s, e) =>
            {
                NotifyOfPropertyChange(() => FullInfo);
            };
            
            ErrorsChanged += (s, e) =>
            {
                NotifyOfPropertyChange(() => BtnEnebled);
            };

        }
        public string FullInfo
        {
            get {return $"{_personModel.FirstName} {_personModel.LastName} {_personModel.Salary}"; }           
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        public bool BtnEnebled { get { return !HasErrors; } }


        public void Save(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;  
            var text = FullInfo;

            worker.DoWork += (o, ea) =>
            {
                _txtService.Save(text, token);
            };
            
            worker.RunWorkerCompleted += (o, ea) =>
            {                
                IsBusy = false;
            };
            
            IsBusy = true;
            worker.RunWorkerAsync();          
        }
        
    }
}
