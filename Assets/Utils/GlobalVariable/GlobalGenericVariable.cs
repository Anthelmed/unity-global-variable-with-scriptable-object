using System;
using UnityEngine;

namespace Utils.GlobalVariable
{
    public class GlobalGenericVariable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private T _initialValue;
        [NonSerialized] private T _runtimeValue;

        public T Value {
            get { return _runtimeValue; }
            set
            {
                if (_runtimeValue == null || _runtimeValue.Equals(value)) return;

                _runtimeValue = value;

                OnValueChanged?.Invoke();
            }
        }

        public delegate void ValueAction();
        public event ValueAction OnValueChanged;

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            Value = _initialValue;
        }
    }
}
