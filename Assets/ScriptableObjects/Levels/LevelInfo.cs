using Udar.SceneManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableObjects.Levels
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "ScriptableObjects/LevelInfo")]
    public class LevelInfo : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private string feature;
        [SerializeField] private SceneField _scene;
        [SerializeField] private Sprite levelPreview;     
        
        public string Name => name;
        public string Feature => feature;
        public Sprite LevelPreview => levelPreview;


        public void LoadLevel()
        {
            SceneManager.LoadScene(_scene.Name);
        }
    }
}