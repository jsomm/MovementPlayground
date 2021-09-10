using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MovementPlayground.ResourceBars
{
    public abstract class ResourceBarBase : MonoBehaviour
    {
        TMP_Text _resourceText;        
        Slider _slider;

        public int CurrentResource { get { return (int)_slider.value; } }
        public int MaxResource { get { return (int)_slider.maxValue; } }

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _resourceText = GetComponentInChildren<TMP_Text>();
        }

        public void SetMaxResource(int max)
        {
            _slider.maxValue = max;
            _slider.value = max;
            UpdateText();
        }

        public void SetResource(int resource)
        {
            _slider.value = resource;
            UpdateText();
        }

        public void RefillResource()
        {
            if (_slider.value != _slider.maxValue)
                _slider.value = _slider.maxValue;
            UpdateText();
        }

        public void UpdateText()
        {
            _resourceText.text = _slider.value.ToString() + " / " + _slider.maxValue.ToString();
        }
    }
}
