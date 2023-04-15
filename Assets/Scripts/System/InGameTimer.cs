using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Script.System
{
    public class InGameTimer : MonoBehaviour
    {
        public event UnityAction TimeLeft;

        public void StartTimer(float time)
        {
            StartCoroutine(WaitTime(time));
        }

        private IEnumerator WaitTime(float time)
        {
            yield return new WaitForSeconds(time);
            TimeLeft?.Invoke();
            gameObject.SetActive(false);
        }
    }
}