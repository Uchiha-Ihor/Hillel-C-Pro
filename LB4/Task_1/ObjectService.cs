using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB4.Task_1
{
    internal abstract class ObjectService<T> (int _value) where T : ObjectService<T>
    {
        private int value = _value;

        protected abstract T CreateInstance(int newValue);


        // + or -
        public static T operator +(ObjectService<T> _object1, ObjectService<T> _object2)
        {
            return _object1.CreateInstance(_object1.value + _object2.value);
        }
        public static T operator -(ObjectService<T> _object1, ObjectService<T> _object2)
        {
            return _object1.CreateInstance(_object1.value - _object2.value);
        }
        public static T operator +(ObjectService<T> _object, int value)
        {
            return _object.CreateInstance(_object.value + value);
        }
        public static T operator -(ObjectService<T> _object, int value)
        {
            return _object.CreateInstance(_object.value - value);
        }



        // == or !=
        public static bool operator ==(ObjectService<T> _object1, ObjectService<T> _object2)
        {
            return _object1.value == _object2.value;
        }
        public static bool operator !=(ObjectService<T> _object1, ObjectService<T> _object2)
        {
            return _object1.value != _object2.value;
        }
        public static bool operator ==(ObjectService<T> _object, int _value)
        {
            return _object.value == _value;
        }
        public static bool operator !=(ObjectService<T> _object, int _value)
        {
            return _object.value != _value;
        }



        // < or >
        public static bool operator >(ObjectService<T> _object1, ObjectService<T> _object2)
        {
            return _object1.value > _object2.value;
        }
        public static bool operator <(ObjectService<T> _object1, ObjectService<T> _object2)
        {
            return _object1.value < _object2.value;
        }
        public static bool operator >(ObjectService<T> _object1, int _value)
        {
            return _object1.value > _value;
        }
        public static bool operator <(ObjectService<T> _object1, int _value)
        {
            return _object1.value < _value;
        }



        public override string ToString()
        {
            return value.ToString();
        }
    }
}
