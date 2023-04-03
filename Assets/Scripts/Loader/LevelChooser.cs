using Udar.SceneManager;
using UI.Script;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Loader
{
    public class LevelChooser : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader selectButton;
        [SerializeField] private SceneField _sceneToLoad;
        
        public event UnityAction<SceneField> SceneSelected;

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
            SceneSelected?.Invoke(_sceneToLoad);
        }
    }
}