using System;
using System.Collections;
using Script.Mover;
using Script.Mover.EntityMovier;
using UnityEngine;

namespace Script.GameEntitie
{
    public class EnemyActivator : MonoBehaviour
    {
        [SerializeField] private EnemyMover enemyMover;
        [SerializeField] private float activationTime;
        [SerializeField] private Enemy enemy;
        [SerializeField] private Collider enemyCollider;

        private WaitForSeconds _waitActivation;

        private void Awake()
        {
            Deactivate();
        }

        private void Start()
        {
            _waitActivation = new WaitForSeconds(activationTime);
            StartCoroutine(ActivateEnemy());
        }

        private void Deactivate()
        {
            enemyMover.enabled = false;
            enemy.enabled = false;
            enemyCollider.enabled = false;
        }


        private void Activate()
        {
            enemyMover.enabled = true;  
            enemy.enabled = true;
            enemyCollider.enabled = true;
        }

        private IEnumerator ActivateEnemy()
        {
            yield return _waitActivation;
            Activate();
        }
    }
}
