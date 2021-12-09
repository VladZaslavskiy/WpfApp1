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
    public class PersonViewModel : ModelAny<PersonModel>
    {
        private readonly ISaveToTxtService _txtService;
        private readonly PersonModel _personModel;
        
        //public ICanDoEvents a = new ICanDoEvents();
        public PersonViewModel(PersonModel model, ISaveToTxtService txtService) : base(model)
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

        
    }
}
