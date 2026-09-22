using UnityEngine;

namespace StrikeZone.Weapons
{
    public class PlayerWeaponPickup : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private WeaponInventory weaponInventory;

        private void Awake()
        {
            if (weaponInventory == null)
            {
                weaponInventory =
                    GetComponent<WeaponInventory>();
            }
        }

        public bool PickUpWeapon(WeaponPickup pickup)
        {
            if (pickup == null || weaponInventory == null)
                return false;

            if (!pickup.CanCollect())
                return false;

            WeaponData weaponData = pickup.Collect();

            if (weaponData == null)
                return false;

            return weaponInventory.TryEquipPickup(
                weaponData
            );
        }
    }
}
