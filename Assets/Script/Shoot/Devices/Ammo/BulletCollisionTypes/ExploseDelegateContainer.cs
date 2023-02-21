using System.Collections;
using NTC.Global.Pool;
using UnityEngine;

namespace Script.Shoot.Devices.Ammo
{
    public class ExploseDelegateContainer : MonoBehaviour
    {
        public delegate void ExploseDelegate(BulletCollector bulletCollector);
    }
}