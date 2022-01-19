using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class OutputViewModel : ModelAny<PersonModel>
    {
        private readonly PersonModel _personModel;
        private readonly IOutFromDbService _outFromDb;
        string SP = "Person_SelectAll";
        

        public OutputViewModel(PersonModel model, IOutFromDbService outFromDb) : base(model)
        {            
            _personModel = model;
            _outFromDb = outFromDb;
        }

        public IList<PersonModel> PersonAllOut()
        {
            return _outFromDb.GetItemList<PersonModel>(SP, _personModel);
        }

        public IEnumerable<PersonModel> Persons 
        {
            get
            {
              return PersonAllOut();
            }             
        }
        
    }
}

