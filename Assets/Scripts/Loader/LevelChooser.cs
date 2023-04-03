using ScriptableObjects.Levels;
using Udar.SceneManager;
using UI.Script;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Loader
{
    public class LevelChooser : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader selectButton;
        [SerializeField] private LevelInfo levelInfo;
        
        public event UnityAction<LevelInfo> SceneSelected;

        private void OnEnable()
        {
            selectButton.ButtonClicked += OnButtonClicked;
        }

        private void OnDisable()
        {
            selectButton.ButtonClicked -= OnButtonClicked;
        }

        private void OnButtonClicked()
        {
            SceneSelected?.Invoke(levelInfo);
        }
    }
}