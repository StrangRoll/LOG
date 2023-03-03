using DG.Tweening;
using UnityEngine.UI;

namespace UI.Script.ReloadView
{
    public class ReloadView
    {
        public void StartReloadAnimation(float animationTime , Image coolTimeImage)
        {
            coolTimeImage.DOFillAmount(360, animationTime).SetEase(Ease.Linear)
                .OnComplete(() => OnAnimationEnded(coolTimeImage)); 
        }

        private void OnAnimationEnded(Image coolTimeImage)
        {
            coolTimeImage.fillAmount = 0;
        }
    }
}