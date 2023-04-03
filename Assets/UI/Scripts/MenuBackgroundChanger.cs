using UnityEngine;
using Random = UnityEngine.Random;

namespace UI.Script
{
    public class MenuBackgroundChanger : MonoBehaviour
    {
        [SerializeField] private GameObject[] levels;

        public void Awake()
        {
            //choice random level from levels
            var levelIndex = Random.Range(0, levels.Length);
            levels[levelIndex].SetActive(true);
        }
    }
}