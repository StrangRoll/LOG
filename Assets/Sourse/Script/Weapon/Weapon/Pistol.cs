public class Pistol : Weapon
{
    protected override void SpawnBullets()
    {
        Instantiate(bullet);
    }
}
