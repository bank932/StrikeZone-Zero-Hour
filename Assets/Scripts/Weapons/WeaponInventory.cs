using UnityEngine;

namespace StrikeZone.Weapons
{
    public class WeaponInventory : MonoBehaviour
    {
        [Header("Weapon Slots")]
        [SerializeField] private WeaponController primaryWeapon;
        [SerializeField] private WeaponController secondaryWeapon;

        private WeaponController currentWeapon;

        public WeaponController CurrentWeapon => currentWeapon;
        public WeaponController PrimaryWeapon => primaryWeapon;
        public WeaponController SecondaryWeapon => secondaryWeapon;

        private void Start()
        {
            EquipPrimary();
        }

        public void EquipPrimary()
        {
            EquipWeapon(primaryWeapon);
        }

        public void EquipSecondary()
        {
            EquipWeapon(secondaryWeapon);
        }

        public void SwitchWeapon()
        {
            if (currentWeapon == primaryWeapon)
            {
                EquipSecondary();
            }
            else
            {
                EquipPrimary();
            }
        }

        public void Fire()
        {
            if (currentWeapon != null)
            {
                currentWeapon.Fire();
            }
        }

        public void Reload()
        {
            if (currentWeapon != null)
            {
                currentWeapon.StartReload();
            }
        }

        public bool TryEquipPickup(WeaponData weaponData)
        {
            if (weaponData == null)
                return false;

            if (primaryWeapon == null)
            {
                return false;
            }

            return true;
        }

        private void EquipWeapon(
            WeaponController weapon
        )
        {
            if (weapon == null)
                return;

            if (currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            currentWeapon = weapon;
            currentWeapon.gameObject.SetActive(true);
        }
    }
}
