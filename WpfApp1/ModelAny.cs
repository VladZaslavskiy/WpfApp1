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
        Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual IList<string> ValidateProperty(string propName)
        {
            return null;
        }
        protected bool _validateUnbound = false;
        protected void NotifyOfPropertyChange(string name, bool validate)
        {
            if (PropertyChanged != null || _validateUnbound)
            {
                if (_enabled)
                    try
                    {
                        if (validate)
                            ValidateProperty(name);

                        if (PropertyChanged != null)
                            PropertyChanged(this, new PropertyChangedEventArgs(name));
                    }
                    catch (Exception ex)
                    {
                      // Log.Error(ex);
                    }
            }
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
            dictionary[binder.Name.ToLower()] = value;

            return true;
        }
        // получение свойства
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();            
            return dictionary.TryGetValue(name, out result);
        }
    }
}
