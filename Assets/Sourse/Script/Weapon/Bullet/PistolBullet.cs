using UnityEngine;

public class PistolBullet : Bullet
{
    public override void Move()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
