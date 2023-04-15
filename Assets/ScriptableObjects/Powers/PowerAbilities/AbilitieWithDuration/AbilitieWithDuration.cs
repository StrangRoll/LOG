using NTC.Global.Pool;
using Script.System;
using UnityEngine;

namespace ScriptableObjects.Powers.PowerAbilities.AbilitieWithDuration
{
    public abstract class AbilitieWithDuration : PowerAbilitie
    {
        [SerializeField] private InGameTimer inGameTimer;
        [SerializeField] private float duration;
        
        public override void ActivateAbilite()
        {
            NightPool.Spawn(inGameTimer);
            inGameTimer.StartTimer(duration);
            Activate();
            inGameTimer.TimeLeft += OnTimeLeft;
        }

        protected abstract void Activate();

        protected abstract void Deactivate();

        private void OnTimeLeft()
        {
            inGameTimer.TimeLeft -= OnTimeLeft;
            Deactivate();
        }
    }
}