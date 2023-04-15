using Script.Input;
using ScriptableObjects.Powers;
using UnityEngine;

namespace Script.Powers
{
    public class PowerUser : MonoBehaviour
    {
        [SerializeField] private Power firstPower;
        [SerializeField] private Power secondPower;

        [SerializeField] private PowerInputRoot powerInputRoot;

        private void Awake()
        {
            firstPower.Reset();
            secondPower.Reset();
        }

        private void OnEnable()
        {
            powerInputRoot.FirstPower += OnFirstPower;
            powerInputRoot.SecondPower += OnSecondPower;
        }

        private void OnDisable()
        {
            powerInputRoot.FirstPower -= OnFirstPower;
            powerInputRoot.SecondPower -= OnSecondPower;
        }

        private void OnSecondPower()
        {
            secondPower.Activate();
        }

        private void OnFirstPower()
        {
            firstPower.Activate();
        }
    }
}