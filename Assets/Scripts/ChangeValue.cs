using GlobalVariable;
using UnityEngine;

public class ChangeValue : MonoBehaviour
{
    [SerializeField] private GlobalFloat _globalFloat;
    [SerializeField] private float _amount;

    public void OnClick()
    {
        _globalFloat.Value += _amount;
    }
}
