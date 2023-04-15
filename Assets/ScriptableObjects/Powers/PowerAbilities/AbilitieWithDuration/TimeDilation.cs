using UnityEngine;

namespace ScriptableObjects.Powers.PowerAbilities.AbilitieWithDuration
{
    [CreateAssetMenu(fileName = "TimeDilation", menuName = "ScriptableObjects/PowerAbilitie/TimeDilation")]

    public class TimeDilation : AbilitieWithDuration
    {
        protected override void Activate()
        {
            Time.timeScale = 0.5f;
        }

        protected override void Deactivate()
        {
            Time.timeScale = 1f;
        }
    }
}