using IJunior.TypedScenes;
using Script.Loader.Info;

namespace Script.Loader
{
    public class MainMenuLoader
    {
        public void LoadToMainMenu()
        {
            var info = new InfoToMainMenu();
            MainMenu.Load(info);
        }
    }
}