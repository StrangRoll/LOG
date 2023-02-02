using UnityEngine;
using UnityEngine.UI;

namespace UI.Script
{
    public class SliderView : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        
        public void ChangeValue(float value, float maxValue)
        {
            slider.value = value/maxValue;
        }

        public void IncreaseValue(float deltaValue, float maxValue)
        {
            slider.value += deltaValue / maxValue;
        }
    }
}