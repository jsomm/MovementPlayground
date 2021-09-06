using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MovementPlayground.ResourceBars
{
    public abstract class ResourceBarBase : MonoBehaviour
    {
        TMP_Text _resourceText;        
        Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _resourceText = GetComponentInChildren<TMP_Text>();
        }

        public void SetMaxResource(int max)
        {
            _slider.maxValue = max;
            _slider.value = max;
            _resourceText.text = _slider.value.ToString() + " / " + _slider.maxValue.ToString();
        }

        public void SetResource(int resource)
        {
            _slider.value = resource;
            _resourceText.text = _slider.value.ToString() + " / " + _slider.maxValue.ToString();
        }
    }
}
