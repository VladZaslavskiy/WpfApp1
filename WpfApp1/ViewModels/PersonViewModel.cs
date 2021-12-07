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
        public string FullInfo
        {
            get {return $"{_personModel.FirstName} {_personModel.LastName} {_personModel.Salary}"; }           
        }

        public void Save()
        {
            var text = FullInfo;
            _txtService.SaveToDisc(text);
        }

        List<string> err = new List<string>();
        public bool HasErrors => err.Any();

        public IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            var errors = new List<string>();

            if(propertyName == "Salary" || propertyName ==  null)
            {

                if (_personModel.Salary > 2000)
                    errors.Add("Salary is too big");
                bool latin = true;
                for (int i = 0; i < _personModel.FirstName.Length; i++)
                {
                    if (Char.IsDigit(_personModel.FirstName[i]) || (_personModel.FirstName[i] >= 'a' && _personModel.FirstName[i] <= 'z')
                        || (_personModel.FirstName[i] >= 'A' && _personModel.FirstName[i] <= 'Z'))
                        latin = false;
                }
                for (int i = 0; i < _personModel.LastName.Length; i++)
                {
                    if (Char.IsDigit(_personModel.LastName[i]) || (_personModel.LastName[i] >= 'a' && _personModel.LastName[i] <= 'z')
                        || (_personModel.LastName[i] >= 'A' && _personModel.LastName[i] <= 'Z'))
                        latin = false;
                }
                if (!latin)
                {
                    errors.Add("Enter the name in latin letters");
                    latin = true;
                }
            }
            err = errors;
            return errors;
        }
               
        private void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
