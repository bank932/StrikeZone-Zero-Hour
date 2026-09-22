using UnityEngine;

namespace StrikeZone.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] private string weaponName = "Prototype Rifle";
        [SerializeField] private float damage = 25f;
        [SerializeField] private float fireRate = 8f;
        [SerializeField] private float range = 150f;

        [Header("Magazine")]
        [SerializeField] private int magazineSize = 30;
        [SerializeField] private float reloadTime = 2f;

        [Header("References")]
        [SerializeField] private Camera playerCamera;
        [SerializeField] private ParticleSystem muzzleFlash;

        private int currentAmmo;
        private float nextFireTime;
        private bool isReloading;

        public string WeaponName => weaponName;
        public int CurrentAmmo => currentAmmo;
        public int MagazineSize => magazineSize;
        public bool IsReloading => isReloading;

        private void Awake()
        {
            currentAmmo = magazineSize;

            if (playerCamera == null)
            {
                playerCamera = Camera.main;
            }
        }

        public void Fire()
        {
            if (isReloading)
                return;

            if (currentAmmo <= 0)
            {
                StartReload();
                return;
            }

            if (Time.time < nextFireTime)
                return;

            nextFireTime =
                Time.time + (1f / fireRate);

            currentAmmo--;

            if (muzzleFlash != null)
            {
                muzzleFlash.Play();
            }

            if (playerCamera == null)
                return;

            Ray ray = new Ray(
                playerCamera.transform.position,
                playerCamera.transform.forward
            );

            if (Physics.Raycast(
                ray,
                out RaycastHit hit,
                range
            ))
            {
                Player.PlayerHealth target =
                    hit.collider.GetComponentInParent<Player.PlayerHealth>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }

        public void StartReload()
        {
            if (isReloading ||
                currentAmmo >= magazineSize)
                return;

            StartCoroutine(ReloadRoutine());
        }

        private System.Collections.IEnumerator ReloadRoutine()
        {
            isReloading = true;

            yield return new WaitForSeconds(
                reloadTime
            );

            currentAmmo = magazineSize;
            isReloading = false;
        }
    }
}
