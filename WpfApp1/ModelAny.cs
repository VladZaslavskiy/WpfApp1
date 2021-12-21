using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp1
{
    public class ModelAny<TObject> : DynamicObject, INotifyPropertyChanged, INotifyDataErrorInfo
        where TObject : class
    {
        TObject _value;
        private readonly PropertyInfo[] _props;
        public ModelAny(TObject obj)
        {
            _value = obj;
            Type t = typeof(TObject);
            _props = t.GetProperties();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
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

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name;

            var propertyInfo = _props.Single(p => p.Name == name);
            result = propertyInfo.GetValue(_value);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var name = binder.Name;

            var propertyInfo = _props.Single(p => p.Name == name);
            
            propertyInfo.SetValue(_value, value);
            OnErrorsChanged(name);
            return true;
        }

        public bool HasErrors => GetErrors(null).OfType<object>().Any();

        //Func<TObject, string> err;
        private IList<(string propName, Func<TObject, string> validatorFunc)> _validators 
                                = new List<(string propName, Func<TObject, string> validatorFunc)>();

        public IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            var errors = new List<string>();

            //if (_validators != null)
            foreach (var pair in _validators)
            {
                if (propertyName == pair.propName || propertyName == null)
                {
                    string adErr = pair.validatorFunc.Invoke(_value);
                    if (!string.IsNullOrEmpty(adErr))
                    errors.Add(adErr);
                }
            }
            
            return errors;
        }

        private void OnErrorsChanged([CallerMemberName] string propertyName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void AddValidation(string propertyName, Func<TObject, string> func)
        {

            _validators.Add((propertyName, func));
        }

    }
}
