using System;
using Script.Pause;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Script.UIActivator
{
    public class PauseMenuActivator : MonoBehaviour, IPausable
    {
        [SerializeField] private Image pauseMenu;
        
        [Inject] private PauseManager _pauseManager;

        private void OnEnable()
        {
            _pauseManager.Register(this);
        }

        private void OnDisable()
        {
            _pauseManager.UnRegister(this); 
        }

        public void Pause(bool isPause)
        {
            pauseMenu.gameObject.SetActive(isPause);
        }

        public void ForPauseTemple()
        {
            Pause(false);
        }
    }
}