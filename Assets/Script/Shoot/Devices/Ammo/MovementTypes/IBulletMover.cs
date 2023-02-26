namespace Script.Shoot.Devices.Ammo.MovementTypes
{
    public interface IBulletMover
    {
        public void MoveEachFrame();

        public void StartMove();

        public void StopMove();
    }
}