using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace WpfApp1.Models
{
    public class PersonModel
    {
        private string _firstName;
        private string _lastName;
        private int _salary;


        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                _firstName = value;
                //NotifyOfPropertyChange(() => FirstName);
            }
        }       

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }




    }
}
