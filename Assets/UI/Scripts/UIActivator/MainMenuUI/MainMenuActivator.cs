using UI.Script;
using UnityEngine;

namespace UI.Scripts.UIActivator.MainMenuUI
{
    public class MainMenuActivator : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader goToLevelSelectButton;
        [SerializeField] private ButtonClickReader goToMenuButton;
        [SerializeField] private RectTransform mainMenuPanel;

        private void OnEnable()
        {
            goToLevelSelectButton.ButtonClicked += OnGoToLevelSelectButtonClicked;
            goToMenuButton.ButtonClicked += OnGoToMenuButtonClicked;
        }

        private void OnDisable()
        {
            goToLevelSelectButton.ButtonClicked -= OnGoToLevelSelectButtonClicked;
            goToMenuButton.ButtonClicked -= OnGoToMenuButtonClicked;
        }

        private void OnGoToMenuButtonClicked()
        {
            Activate();
        }

        private void OnGoToLevelSelectButtonClicked()
        {
            Deactivate();
        }

        private void Activate()
        {
            mainMenuPanel.gameObject.SetActive(true);
        }

        private void Deactivate()
        {
            mainMenuPanel.gameObject.SetActive(false);
        }
    }
}