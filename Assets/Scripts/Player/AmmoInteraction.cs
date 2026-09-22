using UnityEngine;
using StrikeZone.Weapons;

namespace StrikeZone.Player
{
    public class AmmoInteraction : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private WeaponAmmo weaponAmmo;

        [Header("Interaction")]
        [SerializeField] private float interactionRange = 3f;
        [SerializeField] private LayerMask interactionLayers = ~0;

        private Camera playerCamera;

        private void Awake()
        {
            playerCamera = Camera.main;

            if (weaponAmmo == null)
            {
                weaponAmmo =
                    GetComponent<WeaponAmmo>();
            }
        }

        public bool TryPickUpAmmo()
        {
            if (playerCamera == null ||
                weaponAmmo == null)
            {
                return false;
            }

            Ray ray = new Ray(
                playerCamera.transform.position,
                playerCamera.transform.forward
            );

            if (!Physics.Raycast(
                ray,
                out RaycastHit hit,
                interactionRange,
                interactionLayers
            ))
            {
                return false;
            }

            AmmoPickup pickup =
                hit.collider.GetComponentInParent<AmmoPickup>();

            if (pickup == null)
                return false;

            return pickup.Collect(weaponAmmo);
        }
    }
}
