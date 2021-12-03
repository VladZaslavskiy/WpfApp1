using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class PersonViewModel : ModelAny<PersonModel>        
    {
        private readonly ISaveToTxtService _txtService;
        private readonly PersonModel _personModel;
        public PersonViewModel(PersonModel model, ISaveToTxtService txtService) : base(model)
        {
            _txtService = txtService;
            _personModel = model;
        }

        public string FullInfo
        {
            get
            {
                return $"{_personModel.FirstName} {_personModel.LastName} {_personModel.Salary}";
            }
           
        }

        public void Save()
        {
            var text = string.Empty;
            _txtService.SaveToDisc(text);                
        }
    }
}
