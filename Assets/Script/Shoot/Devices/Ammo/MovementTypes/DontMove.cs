using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.MovementTypes
{
    public class DontMove : IBulletMover
    {
        public void Move()
        {
            return;
        }
    }
}