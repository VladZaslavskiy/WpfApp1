using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class PersonViewModel : ModelAny<PersonModel>        
    {
        private ISaveToTxtService _txtService;
        public PersonViewModel(PersonModel model,ISaveToTxtService txtService) : base(model)
        {
            _txtService = txtService;
        }
        
    }
}
