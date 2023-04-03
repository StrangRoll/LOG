using Udar.SceneManager;
using UI.Script;
using UnityEngine;
using UnityEngine.SceneManagement;
using NotImplementedException = System.NotImplementedException;

namespace Script.Loader
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader startButton;
        [SerializeField] private LevelChooser[] levelChoosers;

        private SceneField _sceneToLoad;
        
        private void OnEnable()
        {
            foreach (var levelChooser in levelChoosers)
            {
                levelChooser.SceneSelected += OnSceneSelected;
            }
            
            startButton.ButtonClicked += OnStartButtonClicked;
        }

        private void OnDisable()
        {
            foreach (var levelChooser in levelChoosers)
            {
                levelChooser.SceneSelected -= OnSceneSelected;
            }

            startButton.ButtonClicked -= OnStartButtonClicked;
        }

        private void OnSceneSelected(SceneField sceneToLoad)
        {
            _sceneToLoad = sceneToLoad;
        }

        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene(_sceneToLoad.Name);
        }
    }
}