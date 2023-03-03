using System;
using System.Collections;
using Script.GameEntitie;
using Script.Shoot.Devices.Arms;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Script.ReloadView
{
    public class WeaponReloaderView : MonoBehaviour
    {
        [Inject] private Player _player;
        
        [SerializeField] private Image coolTimeImage;
        [SerializeField] private Image iconImage;
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Sprite activeIconSprite;
        [SerializeField] private Sprite inactiveIconSprite;
        [SerializeField] private Sprite activeBackgoundSprite;
        [SerializeField] private Sprite inactiveBackgoundSprite;

        private readonly ReloadView _reloadView = new ReloadView();
        private Weapon _currentWeapon = null;
        
        private bool IsCurrentWeaponNotNull => _currentWeapon != null;

        private void OnEnable()
        {
            _player.WeaponChanged += OnWeaponChanged;
        }

        private void OnDisable()
        {
            _player.WeaponChanged -= OnWeaponChanged;
        }

        private void OnWeaponChanged(Weapon currentWeapon)
        {
            if (IsCurrentWeaponNotNull)
                _currentWeapon.WeaponReloadStarted -= OnWeaponReloadStarted;
            
            _currentWeapon = currentWeapon;
            _currentWeapon.WeaponReloadStarted += OnWeaponReloadStarted;
        }

        private void OnWeaponReloadStarted(float reloadTime)
        {
            ChangeToInactiveImage();
            _reloadView.StartReloadAnimation(reloadTime, coolTimeImage);
            StartCoroutine(WaitReloadEnded(reloadTime));
        }

        private IEnumerator WaitReloadEnded(float reloadTime)
        {
            yield return new WaitForSeconds(reloadTime);
            ChangeToActiveImage();
        }

        private void ChangeToActiveImage()
        {
            iconImage.sprite = activeIconSprite;
            backgroundImage.sprite = activeBackgoundSprite;
        }

        private void ChangeToInactiveImage()
        {
            iconImage.sprite = inactiveIconSprite;
            backgroundImage.sprite = inactiveBackgoundSprite;
        }
    }
}