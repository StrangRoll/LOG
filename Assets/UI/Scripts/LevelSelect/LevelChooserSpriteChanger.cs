using System;
using Script.Loader;
using ScriptableObjects.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Script.LevelSelect
{
    public class LevelChooserSpriteChanger : MonoBehaviour
    {
        [SerializeField] private Sprite activeSprite;
        [SerializeField] private Sprite inactiveSprite;
        [SerializeField] private Image image;
        [SerializeField] private LevelChooser[] othersLevelChoosers;
        [SerializeField] private LevelChooser thisLevelChooser;

        private void OnEnable()
        {
            foreach (var levelChooser in othersLevelChoosers)
            {
                levelChooser.SceneSelected += OnOtherSceneSelected;
            }

            thisLevelChooser.SceneSelected += OnThisLevelSelected;
        }

        private void OnDisable()
        { 
            foreach (var levelChooser in othersLevelChoosers)
            {
                levelChooser.SceneSelected -= OnOtherSceneSelected;
            }
            
            thisLevelChooser.SceneSelected += OnThisLevelSelected;
        }

        private void OnOtherSceneSelected(LevelInfo levelInfo)
        {
            image.sprite = inactiveSprite;
        }

        private void OnThisLevelSelected(LevelInfo levelInfo)
        {
            image.sprite = activeSprite;
        }
    }
}