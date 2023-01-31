using System.Collections;
using Script.Mover;
using UnityEngine;

namespace Script.GameEntitie
{
    public class EnemyActivator : MonoBehaviour
    {
        [SerializeField] private EnemyMover enemyMover;
        [SerializeField] private float activationTime;
        [SerializeField] private Enemy enemy;

        private WaitForSeconds _waitActivation;

        private void Start()
        {
            Deactivate();
            _waitActivation = new WaitForSeconds(activationTime);
            StartCoroutine(ActivateEnemy());
        }

        private void Deactivate()
        {
            enemyMover.enabled = false;
            enemy.enabled = false;
        }


        private void Activate()
        {
            enemyMover.enabled = true;  
            enemy.enabled = true;
        }

        private IEnumerator ActivateEnemy()
        {
            yield return _waitActivation;
            Activate();
        }
    }
}
