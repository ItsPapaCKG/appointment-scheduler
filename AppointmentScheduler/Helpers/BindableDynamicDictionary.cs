using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduler.Helpers
{
    public sealed class BindableDynamicDictionary : DynamicObject, INotifyPropertyChanged
    {

        private readonly Dictionary<string, object> _dictionary;

        public BindableDynamicDictionary()
        {
            _dictionary = new Dictionary<string, object>();
        }


        public BindableDynamicDictionary(IDictionary<string, object> source)
        {
            _dictionary = new Dictionary<string, object>(source);
        }

        public object this[string key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                _dictionary[key] = value;
                RaisePropertyChanged(key);
            }
        }


        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            return _dictionary.TryGetValue(binder.Name, out result);
        }


            public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name] = value;
            RaisePropertyChanged(binder.Name);
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _dictionary.Keys;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            var propChange = PropertyChanged;
            if (propChange == null) return;
            propChange(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

