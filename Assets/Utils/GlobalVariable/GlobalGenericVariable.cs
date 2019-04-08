using System;
using UnityEngine;

namespace Utils.GlobalVariable
{
    public class GlobalGenericVariable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private T _initialValue;
        [NonSerialized] private T _runtimeValue;

        [Header("Editor only")] 
        [SerializeField] private bool _saveDuringPlayMode = false;

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
            if (_saveDuringPlayMode)
                _initialValue = Value;
        }

        public void OnAfterDeserialize()
        {
            Value = _initialValue;
        }
    }
}
