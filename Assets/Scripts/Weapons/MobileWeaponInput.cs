using UnityEngine;

namespace StrikeZone.Weapons
{
    public class MobileWeaponInput : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private WeaponController weaponController;

        private bool firing;

        private void Awake()
        {
            if (weaponController == null)
            {
                weaponController =
                    GetComponent<WeaponController>();
            }
        }

        private void Update()
        {
            if (weaponController == null)
                return;

            if (firing)
            {
                weaponController.Fire();
            }
        }

        public void SetFire(bool value)
        {
            firing = value;
        }

        public void FireOnce()
        {
            if (weaponController != null)
            {
                weaponController.Fire();
            }
        }

        public void Reload()
        {
            if (weaponController != null)
            {
                weaponController.StartReload();
            }
        }
    }
}
