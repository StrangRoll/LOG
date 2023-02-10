using System;
using IJunior.TypedScenes;
using UI.Script;
using UnityEngine;
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

            var info = new InfoToLevel();

            switch (levelIndex)
            {
                case (1):
                    Level_1.Load(info);
                    break;
                case (2):
                    Level_2.Load(info);
                    break;
                case (3):
                    Level_3.Load(info);
                    break;
                case (4):
                    Level_4.Load(info);
                    break;
                default:
                    Debug.LogError("Invalid level index: " + levelIndex);
                    break;
            }
        }
    }
}