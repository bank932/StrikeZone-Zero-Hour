using UnityEngine;

namespace StrikeZone.Weapons
{
    public class WeaponAmmo : MonoBehaviour
    {
        [Header("Ammo")]
        [SerializeField] private int reserveAmmo = 120;
        [SerializeField] private int maxReserveAmmo = 180;

        public int ReserveAmmo => reserveAmmo;
        public int MaxReserveAmmo => maxReserveAmmo;

        public bool HasReserveAmmo => reserveAmmo > 0;

        public void AddAmmo(int amount)
        {
            if (amount <= 0)
                return;

            reserveAmmo = Mathf.Clamp(
                reserveAmmo + amount,
                0,
                maxReserveAmmo
            );
        }

        public bool ConsumeAmmo(int amount)
        {
            if (amount <= 0)
                return true;

            if (reserveAmmo < amount)
                return false;

            reserveAmmo -= amount;
            return true;
        }

        public void SetReserveAmmo(int amount)
        {
            reserveAmmo = Mathf.Clamp(
                amount,
                0,
                maxReserveAmmo
            );
        }

        public void SetMaxReserveAmmo(int amount)
        {
            maxReserveAmmo = Mathf.Max(0, amount);

            reserveAmmo = Mathf.Clamp(
                reserveAmmo,
                0,
                maxReserveAmmo
            );
        }

        public void ResetAmmo()
        {
            reserveAmmo = maxReserveAmmo;
        }
    }
}
