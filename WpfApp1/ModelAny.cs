using Caliburn.Micro;
using System;
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
    public class ModelAny<TObject> : DynamicObject, INotifyPropertyChanged
        where TObject : class
    {
        // Dictionary<string, object> dictionary = new Dictionary<string, object>();

        TObject _value;
        private readonly PropertyInfo[] _props;
        public ModelAny(TObject obj)
        {
            _value = obj;
            Type t = typeof(TObject);
            _props = t.GetProperties();
        }
        //protected virtual TObject GetObjectInstance()
        //{
        //    return Activator.CreateInstance<TObject>();
        //}
        //public TObject Value
        //{
        //    get
        //    {
        //        return _value = _value ?? GetObjectInstance(); ;
        //    }

        //    set
        //    {
        //        _value = value;
        //        NotifyOfPropertyChange(() => Value);
        //    }
        //}

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
           // NotifyOfPropertyChange(name);
            return true;
        }
        
        
    }
}
