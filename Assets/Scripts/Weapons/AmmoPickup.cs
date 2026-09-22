using UnityEngine;

namespace StrikeZone.Weapons
{
    public class AmmoPickup : MonoBehaviour
    {
        [Header("Ammo")]
        [SerializeField] private int ammoAmount = 30;

        [Header("Pickup")]
        [SerializeField] private bool destroyOnPickup = true;

        public int AmmoAmount => ammoAmount;

        public bool Collect(WeaponAmmo targetAmmo)
        {
            if (targetAmmo == null)
                return false;

            if (ammoAmount <= 0)
                return false;

            targetAmmo.AddAmmo(ammoAmount);

            if (destroyOnPickup)
            {
                Destroy(gameObject);
            }

            return true;
        }

        public void SetAmmoAmount(int amount)
        {
            ammoAmount = Mathf.Max(0, amount);
        }
    }
}
