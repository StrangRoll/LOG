using UnityEngine;

public abstract class Bullet : MonoBehaviour, IMovable
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _speed;

    private void Update()
    {
        Move();
    }

    public abstract void Move();
}
