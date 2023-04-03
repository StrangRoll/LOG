using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Script
{
    public class ButtonClickReader : MonoBehaviour
    {
        [SerializeField] private Button button;

        public event UnityAction ButtonClicked;

        private void OnEnable()
        {
            button.onClick.AddListener(OnButtonClicked);
        }
        
        private void OnDisable()
        {
            button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            ButtonClicked?.Invoke();
        }
    }
}