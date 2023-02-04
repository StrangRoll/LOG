using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Script.UIActivator
{
    public class MainMenuActivator : MonoBehaviour
    {
        [SerializeField] private Image mainMenu;
        [SerializeField] private ButtonClickReader playButton;
        [SerializeField] private ButtonClickReader exitButtonInLose;
        [SerializeField] private ButtonClickReader exitButtonInPause;
        
        private void OnEnable()
        {
            playButton.ButtonClicked += OnPlayButtonClicked;
            exitButtonInLose.ButtonClicked += OnExitButtonClicked;
            exitButtonInPause.ButtonClicked += OnExitButtonClicked;
        }

        private void OnDisable()
        {
            playButton.ButtonClicked -= OnPlayButtonClicked;
            exitButtonInLose.ButtonClicked -= OnExitButtonClicked;
            exitButtonInPause.ButtonClicked -= OnExitButtonClicked;
        }

        private void OnExitButtonClicked()
        {
            mainMenu.gameObject.SetActive(true);    
        }

        private void OnPlayButtonClicked()
        {
            mainMenu.gameObject.SetActive(false);
        }
    }
}