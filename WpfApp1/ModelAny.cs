using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp1
{
    public class ModelAny<TObject> : DynamicObject, INotifyPropertyChanged
        where TObject : class
    {
        // Dictionary<string, object> dictionary = new Dictionary<string, object>();

        TObject _value;
        protected virtual TObject GetObjectInstance()
        {
            return Activator.CreateInstance<TObject>();
        }
        public TObject Value
        {
            get
            {
                return _value = _value ?? GetObjectInstance(); ;
            }

            set
            {
                _value = value;
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

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
          Value[binder.Name.ToLower()] = _value;

            return true;
        }
        // получение свойства
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();            
            return Value.TryGetValue(name, out result);
        }
    }
}
