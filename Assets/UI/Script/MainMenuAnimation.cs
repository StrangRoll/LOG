using UnityEngine;

namespace UI.Script
{
    public class MainMenuAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform mainMenuTransform;
        [SerializeField] private float animationSpeed;
        [SerializeField] private float maxScale;
        [SerializeField] private float minScale;
        [SerializeField] private int scaleDirection;

        private void Update()
        {
            if (mainMenuTransform.localScale.x < minScale || mainMenuTransform.localScale.x > maxScale)
                scaleDirection *= -1;
            
            mainMenuTransform.localScale += Vector3.one * (scaleDirection * animationSpeed * Time.deltaTime);
        }
    }
}