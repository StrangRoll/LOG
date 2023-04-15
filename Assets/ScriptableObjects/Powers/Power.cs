using Script.Powers;
using ScriptableObjects.Powers.PowerAbilities;
using UnityEngine;

namespace ScriptableObjects.Powers
{
    [CreateAssetMenu(fileName = "Power", menuName = "ScriptableObjects/Power")]

    public class Power : ScriptableObject 
    {
        [SerializeField] private string powerName;
        [SerializeField] private float powerCooldown;
        [SerializeField] private PowerAbilitie powerAbilitie;

        private float _lastActivatedTime;

        public bool CanActivate => Time.time > _lastActivatedTime + powerCooldown;

        public void Activate()
        {
            if (CanActivate == false) 
                return;
            
            _lastActivatedTime = Time.time;
            powerAbilitie.ActivateAbilite();
            Debug.Log(powerName + " activated");
        }

        public void Reset()
        {
            _lastActivatedTime = -powerCooldown;
        }
    }
}