using IJunior.TypedScenes;
using Script.Loader.Info;
using UI.Script;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Script.Loader.LoadHandlers
{
    public class MainMenuLoadHandler : MonoBehaviour, ISceneLoadHandler<InfoToMainMenu>
    {
        [SerializeField] private MenuBackgroundChanger backgroundChanger;

        public void OnSceneLoaded(InfoToMainMenu info)
        {
            Time.timeScale = 1.0f;
        }
    }
}