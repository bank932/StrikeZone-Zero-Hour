using UnityEngine;

namespace StrikeZone.Weapons
{
    public class WeaponPickup : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] private WeaponData weaponData;

        [Header("Pickup")]
        [SerializeField] private bool destroyOnPickup = true;

        public WeaponData WeaponData => weaponData;

        public bool CanCollect()
        {
            return weaponData != null;
        }

        public WeaponData Collect()
        {
            if (!CanCollect())
                return null;

            WeaponData collectedWeapon = weaponData;

            if (destroyOnPickup)
            {
                Destroy(gameObject);
            }

            return collectedWeapon;
        }

        public void SetWeaponData(WeaponData data)
        {
            weaponData = data;
        }
    }
}
