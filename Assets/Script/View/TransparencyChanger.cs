using DG.Tweening;
using UnityEngine;

namespace Script.View
{
    public class TransparencyChanger
    {
        private readonly Renderer _renderer;
        private readonly float _activationTime;

        public TransparencyChanger(Renderer renderer, float activationTime)
        {
            _renderer = renderer;
            _activationTime = activationTime;
        }

        public void Activate()
        {
            _renderer.material.DOFade(0, 0);
            _renderer.material.DOFade(1, _activationTime).SetEase(Ease.InBounce, 3, 1);
        }
    }
}