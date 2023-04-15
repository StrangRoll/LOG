using System.Collections;
using NTC.Global.Pool;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using NotImplementedException = System.NotImplementedException;

namespace Script.System
{
    public class InGameTimer : MonoBehaviour, IPoolItem
    {
        public event UnityAction TimeLeft;

        private float _time;

        public void SetTime(float time)
        {
            _time = time;
        }
        
        public void OnSpawn()
        {
            StartCoroutine(WaitTime());
        }

        public void OnDespawn()
        {
            return;
        }

        private IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(_time);
            Debug.Log(_time);
            TimeLeft?.Invoke();
            gameObject.SetActive(false);
        }
    }
}