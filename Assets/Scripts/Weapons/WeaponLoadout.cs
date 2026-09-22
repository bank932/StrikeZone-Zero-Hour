using System.Collections.Generic;
using UnityEngine;

namespace StrikeZone.Weapons
{
    public class WeaponLoadout : MonoBehaviour
    {
        [Header("Base Weapon")]
        [SerializeField] private WeaponData weaponData;

        [Header("Attachments")]
        [SerializeField] private List<WeaponAttachment> attachments =
            new List<WeaponAttachment>();

        public WeaponData WeaponData => weaponData;
        public IReadOnlyList<WeaponAttachment> Attachments => attachments;

        public float Damage => GetModifiedDamage();
        public float FireRate => GetModifiedFireRate();
        public float Range => GetModifiedRange();
        public float Recoil => GetModifiedRecoil();
        public float Accuracy => GetModifiedAccuracy();
        public int MagazineSize => GetModifiedMagazineSize();
        public float ReloadTime => GetModifiedReloadTime();
        public float MovementPenalty => GetModifiedMovementPenalty();

        public void SetWeaponData(WeaponData data)
        {
            weaponData = data;
        }

        public bool AddAttachment(
            WeaponAttachment attachment
        )
        {
            if (attachment == null)
                return false;

            if (HasAttachmentType(
                attachment.attachmentType))
            {
                return false;
            }

            attachments.Add(attachment);
            return true;
        }

        public bool RemoveAttachment(
            AttachmentType attachmentType
        )
        {
            for (int i = attachments.Count - 1; i >= 0; i--)
            {
                if (attachments[i] != null &&
                    attachments[i].attachmentType ==
                    attachmentType)
                {
                    attachments.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void ClearAttachments()
        {
            attachments.Clear();
        }

        public bool HasAttachmentType(
            AttachmentType attachmentType
        )
        {
            for (int i = 0; i < attachments.Count; i++)
            {
                if (attachments[i] != null &&
                    attachments[i].attachmentType ==
                    attachmentType)
                {
                    return true;
                }
            }

            return false;
        }

        private float GetModifiedDamage()
        {
            if (weaponData == null)
                return 0f;

            float value = weaponData.damage;

            foreach (WeaponAttachment attachment in attachments)
            {
                if (attachment != null)
                    value += attachment.damageModifier;
            }

            return Mathf.Max(0f, value);
        }

        private float GetModifiedFireRate()
        {
            if (weaponData == null)
                return 0f;

            float value = weaponData.fireRate;

            foreach (WeaponAttachment attachment in attachments)
            {
                if (attachment != null)
                    value += attachment.fireRateModifier;
            }

            return Mathf.Max(0.1f, value);
        }

        private float GetModifiedRange()
        {
            if (weaponData == null)
                return 0f;

            float value = weaponData.range;

            foreach (WeaponAttachment attachment in attachments)
            {
                if (attachment != null)
                    value += attachment.rangeModifier;
            }

            return Mathf.Max(1f, value);
        }

        private float GetModifiedRecoil()
        {
            if (weaponData == null)
                return 0f;

            float value = weaponData.recoil;

            foreach (WeaponAttachment attachment in attachments)
            {
                if (attachment != null)
                    value += attachment.recoilModifier;
            }

            return Mathf.Clamp01(value);
        }

        private float GetModifiedAccuracy()
        {
            if (weaponData == null)
                return 0f;

            float value = weaponData.accuracy;

            foreach (WeaponAttachment attachment in attachments)
            {
                if (attachment != null)
                    value += attachment.accuracyModifier;
            }

            return Mathf.Clamp01(value);
        }

        private int GetModifiedMagazineSize()
        {
            if (weaponData == null)
                return 0;

            int value = weaponData.magazineSize;

            foreach (WeaponAttachment attachment in attachments)
            {
                if (attachment != null)
                    value += attachment.magazineSizeModifier;
            }

            return Mathf.Max(1, value);
        }

        private float GetModifiedReloadTime()
        {
            if (weaponData == null)
                return 0f;

            float value = weaponData.reloadTime;

            foreach (WeaponAttachment attachment in attachments)
            {
                if (attachment != null)
                    value += attachment.reloadTimeModifier;
            }

            return Mathf.Max(0.1f, value);
        }

        private float GetModifiedMovementPenalty()
        {
            if (weaponData == null)
                return 0f;

            float value = weaponData.movementPenalty;

            foreach (WeaponAttachment attachment in attachments)
            {
                if (attachment != null)
                    value += attachment.movementPenaltyModifier;
            }

            return Mathf.Clamp01(value);
        }
    }
}
