using UnityEngine;

namespace Script.System
{
    public class CameraChanger : MonoBehaviour
    {
        [SerializeField] private Camera gameCamera;
        [SerializeField] private Camera mainMenuCamera;

        public void ActivateGameCamera()
        {
            gameCamera.gameObject.SetActive(true);
            mainMenuCamera.gameObject.SetActive(false);
        }

        public void ActivateMainMenuCamera()
        {
            gameCamera.gameObject.SetActive(false);
            mainMenuCamera.gameObject.SetActive(true);
        }
    }
}