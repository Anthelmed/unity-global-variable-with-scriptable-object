using GlobalVariable;
using TMPro;
using UnityEngine;

public class DisplayValue : MonoBehaviour
{
     [SerializeField] private GlobalFloat _globalFloat;
     [SerializeField] private TextMeshProUGUI _textMeshPro;

     private void Start()
     {
          _globalFloat.OnValueChanged += UpdateText;
          UpdateText();
     }

     private void UpdateText()
     {
          _textMeshPro.text = _globalFloat.Value.ToString();
     }
}
