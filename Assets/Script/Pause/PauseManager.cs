using System.Collections.Generic;
using UnityEngine;

namespace Script.Pause
{
    public class PauseManager: MonoBehaviour, IPausable
    {
        private List<IPausable> _pausablesList = new List<IPausable>();
        

        public bool IsPause { get; private set; }
        public void Pause(bool isPause)
        {
            IsPause = isPause;

            Time.timeScale = IsPause ? 0 : 1;

            foreach (var pausable in _pausablesList)
            {
                pausable.Pause(isPause);
            }

        }

        public void ChangePauseState()
        {
            Pause(!IsPause);
        }

        private void Register(IPausable pausable)
        {
            _pausablesList.Add(pausable);
        }

        private void Unregister(IPausable pausable)
        {
            try
            {
                _pausablesList.Remove(pausable);
            }
            catch
            {
                Debug.LogError("Unable to remove pausable from list");
            }
        }
    }
}