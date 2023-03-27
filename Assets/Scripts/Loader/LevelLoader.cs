using UI.Script;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Script.Loader
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader startButton;

        private const int LevelsCount = 4;

        private void OnEnable()
        {
            startButton.ButtonClicked += OnStartButtonClicked;
        }

        private void OnDisable()
        {
            startButton.ButtonClicked -= OnStartButtonClicked;
        }

        private void OnStartButtonClicked()
        {
            var levelIndex = Random.Range(1, LevelsCount + 1);
            
            switch (levelIndex)
            {
                case (1):
                    SceneManager.LoadScene(ScenesID.Level1);
                    break;
                case (2):
                    SceneManager.LoadScene(ScenesID.Level2);
                    break;
                case (3):
                    SceneManager.LoadScene(ScenesID.Level3);
                    break;
                case (4):
                    SceneManager.LoadScene(ScenesID.Level4);
                    break;
                default:
                    Debug.LogError("Invalid level index: " + levelIndex);
                    break;
            }
        }
    }
}