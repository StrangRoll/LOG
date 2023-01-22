public class Pistol : Weapon
{
    public override void SpawnBullets()
    {
        Instantiate(_bullet);
    }
}
