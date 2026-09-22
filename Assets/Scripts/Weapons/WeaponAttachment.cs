using UnityEngine;

namespace StrikeZone.Weapons
{
    [CreateAssetMenu(
        fileName = "NewWeaponAttachment",
        menuName = "StrikeZone/Weapons/Attachment"
    )]
    public class WeaponAttachment : ScriptableObject
    {
        [Header("Identity")]
        public string attachmentName = "Standard Grip";
        public string attachmentId = "ATT_001";

        [Header("Attachment Type")]
        public AttachmentType attachmentType =
            AttachmentType.Grip;

        [Header("Stat Modifiers")]
        public float damageModifier = 0f;
        public float fireRateModifier = 0f;
        public float recoilModifier = 0f;
        public float accuracyModifier = 0f;
        public float rangeModifier = 0f;

        [Header("Magazine")]
        public int magazineSizeModifier = 0;

        [Header("Handling")]
        public float reloadTimeModifier = 0f;
        public float movementPenaltyModifier = 0f;
    }

    public enum AttachmentType
    {
        Optic,
        Muzzle,
        Magazine,
        Grip,
        Stock
    }
}
