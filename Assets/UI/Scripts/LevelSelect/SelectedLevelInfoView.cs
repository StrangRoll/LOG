using System;
using Script.Loader;
using ScriptableObjects.Levels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Script.LevelSelect
{
    public class SelectedLevelInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelName;
        [SerializeField] private TMP_Text levelFeature;
        [SerializeField] private Image levelPreview;
        [SerializeField] private LevelChooser[] levelChoosers;

        private void OnEnable()
        {
            foreach (var levelChooser in levelChoosers)
            {
                levelChooser.SceneSelected += OnSceneSelected;
            }
        }

        private void OnDisable()
        {
            foreach (var levelChooser in levelChoosers)
            {
                levelChooser.SceneSelected -= OnSceneSelected;
            }
        }

        private void OnSceneSelected(LevelInfo levelInfo)
        {
            levelName.text = levelInfo.Name;
            levelFeature.text = levelInfo.Feature;
            levelPreview.sprite = levelInfo.LevelPreview;
        }
    }
}