using NotImplementedException = System.NotImplementedException;

namespace Script.Shoot.Devices.Ammo.MovementTypes
{
    public class DontMove : IBulletMover
    {
        public void MoveEachFrame()
        {
            return;
        }

        public void StartMove()
        {
            return;
        }

        public void StopMove()
        {
            return;
        }
    }
}