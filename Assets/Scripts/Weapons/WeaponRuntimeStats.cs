using UnityEngine;

namespace StrikeZone.Weapons
{
    public class WeaponRuntimeStats : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private WeaponData weaponData;
        [SerializeField] private WeaponLoadout weaponLoadout;

        public float Damage =>
            weaponLoadout != null
                ? weaponLoadout.Damage
                : weaponData != null
                    ? weaponData.damage
                    : 0f;

        public float FireRate =>
            weaponLoadout != null
                ? weaponLoadout.FireRate
                : weaponData != null
                    ? weaponData.fireRate
                    : 0f;

        public float Range =>
            weaponLoadout != null
                ? weaponLoadout.Range
                : weaponData != null
                    ? weaponData.range
                    : 0f;

        public float Recoil =>
            weaponLoadout != null
                ? weaponLoadout.Recoil
                : weaponData != null
                    ? weaponData.recoil
                    : 0f;

        public float Accuracy =>
            weaponLoadout != null
                ? weaponLoadout.Accuracy
                : weaponData != null
                    ? weaponData.accuracy
                    : 0f;

        public int MagazineSize =>
            weaponLoadout != null
                ? weaponLoadout.MagazineSize
                : weaponData != null
                    ? weaponData.magazineSize
                    : 0;

        public float ReloadTime =>
            weaponLoadout != null
                ? weaponLoadout.ReloadTime
                : weaponData != null
                    ? weaponData.reloadTime
                    : 0f;

        public float MovementPenalty =>
            weaponLoadout != null
                ? weaponLoadout.MovementPenalty
                : weaponData != null
                    ? weaponData.movementPenalty
                    : 0f;

        private void Awake()
        {
            if (weaponLoadout == null)
            {
                weaponLoadout =
                    GetComponent<WeaponLoadout>();
            }
        }

        public void SetWeaponData(WeaponData data)
        {
            weaponData = data;

            if (weaponLoadout != null)
            {
                weaponLoadout.SetWeaponData(data);
            }
        }
    }
}
