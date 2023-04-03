using UI.Script;
using UnityEngine;

namespace UI.Scripts.UIActivator.MainMenuUI
{
    public class LevelSelectActivator : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader goToLevelSelectButton;
        [SerializeField] private ButtonClickReader goToMenuButton;
        [SerializeField] private RectTransform levelSelectPanel;

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
            Deactivate();
        }

        private void OnGoToLevelSelectButtonClicked()
        {
            Activate();
        }

        private void Activate()
        {
            levelSelectPanel.gameObject.SetActive(true);
        }

        private void Deactivate()
        {
            levelSelectPanel.gameObject.SetActive(false);
        }
    }
}