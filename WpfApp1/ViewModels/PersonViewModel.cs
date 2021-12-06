using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{

    
    public class PersonViewModel : ModelAny<PersonModel>, INotifyDataErrorInfo
    {
        private readonly ISaveToTxtService _txtService;
        private readonly PersonModel _personModel;
        //public ICanDoEvents a = new ICanDoEvents();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public PersonViewModel(PersonModel model, ISaveToTxtService txtService) : base(model)
        {
            _txtService = txtService;
            _personModel = model;

            
            model.PropertyChanged += (s, e) =>
            {
                NotifyOfPropertyChange(() => FullInfo);
            };

        }

        
        
        //private string _fullInfo;
        public string FullInfo
        {
            get {return $"{_personModel.FirstName} {_personModel.LastName} {_personModel.Salary}"; }           
        }

        public void Save()
        {
            var text = FullInfo;
            _txtService.SaveToDisc(text);
        }

        public bool HasErrors
        {
            get
            {
                return GetErrors(null).OfType<object>().Any();
            }
        }

        
        public virtual IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            return Enumerable.Empty<object>();
        }

        protected void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            OnErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected virtual void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var handler = ErrorsChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }
}
