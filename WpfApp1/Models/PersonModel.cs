using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using Caliburn.Micro;

namespace WpfApp1.Models
{
    public class PersonModel : INotifyPropertyChanged
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
                NotifyOfPropertyChange(() => FirstName);
            }
        }       

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public int Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                NotifyOfPropertyChange(() => Salary);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual IList<string> ValidateProperty(string propName)
        {
            return null;
        }
        // protected bool _validateUnbound = false;
        protected void NotifyOfPropertyChange(string name, bool validate)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }

        public virtual void NotifyOfPropertyChange([CallerMemberName] string name = null)
        {
            NotifyOfPropertyChange(name, true);
        }

        public virtual void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
        {
            NotifyOfPropertyChange(getPropName(property));
        }

        protected string getPropName<TProperty>(Expression<Func<TProperty>> property)
        {
            return property.GetMemberInfo().Name;
        }


    }
}
