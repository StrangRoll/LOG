using UnityEngine.SceneManagement;

namespace Script.Loader
{
    public class MainMenuLoader
    {
        public void LoadToMainMenu()
        {
            SceneManager.LoadScene(ScenesID.MainMenu);
        }
    }
}