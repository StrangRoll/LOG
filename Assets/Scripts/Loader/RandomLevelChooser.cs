using UnityEngine;
using UnityEngine.UI;

namespace Script.Loader
{
    public class RandomLevelChooser : MonoBehaviour
    {
        [SerializeField] private Button[] levelSelectedButtons;

        private void OnEnable()
        {
            var randomIndex = Random.Range(0, levelSelectedButtons.Length);
            var randomButton = levelSelectedButtons[randomIndex];
            randomButton.onClick.Invoke();
        }
    }
}