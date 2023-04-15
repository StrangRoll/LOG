using UnityEngine;

namespace ScriptableObjects.Powers.PowerAbilities
{
    [CreateAssetMenu(fileName = "LogAbility", menuName = "ScriptableObjects/PowerAbilitie/LogAbility")]

    public class LogAbility : PowerAbilitie
    {
        public override void ActivateAbilite()
        {
            Debug.Log("Ability activated");
        }
    }
}