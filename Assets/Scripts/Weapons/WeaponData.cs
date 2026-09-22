using UnityEngine;

namespace StrikeZone.Weapons
{
    [CreateAssetMenu(
        fileName = "NewWeaponData",
        menuName = "StrikeZone/Weapons/Weapon Data"
    )]
    public class WeaponData : ScriptableObject
    {
        [Header("Identity")]
        public string weaponName = "Prototype Rifle";
        public string weaponId = "WPN_001";

        [Header("Combat")]
        public float damage = 25f;
        public float fireRate = 8f;
        public float range = 150f;

        [Header("Magazine")]
        public int magazineSize = 30;
        public float reloadTime = 2f;

        [Header("Weapon Type")]
        public WeaponType weaponType =
            WeaponType.AssaultRifle;

        [Header("Handling")]
        [Range(0f, 1f)]
        public float recoil = 0.25f;

        [Range(0f, 1f)]
        public float accuracy = 0.85f;

        [Range(0f, 1f)]
        public float movementPenalty = 0.1f;
    }

    public enum WeaponType
    {
        AssaultRifle,
        SubmachineGun,
        Shotgun,
        SniperRifle,
        MarksmanRifle,
        LightMachineGun,
        Pistol
    }
}
