using System;
using UnityEngine;

namespace Script.Mover.Rotator
{
    public class MenuCameraRotator : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Transform menuCameraParent;
        [SerializeField] private float maxY;
        [SerializeField] private float minY;
        [SerializeField] private int direcion;

        private void Update()
        {
            menuCameraParent.Rotate(Vector3.up, rotationSpeed * direcion * Time.deltaTime);

            if (menuCameraParent.transform.rotation.y < minY || menuCameraParent.transform.rotation.y > maxY)
                direcion *= -1;
        }
    }
}