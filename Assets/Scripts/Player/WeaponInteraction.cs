using UnityEngine;
using StrikeZone.Weapons;

namespace StrikeZone.Player
{
    public class WeaponInteraction : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerWeaponPickup weaponPickup;

        [Header("Interaction")]
        [SerializeField] private float interactionRange = 3f;
        [SerializeField] private LayerMask interactionLayers = ~0;

        private Camera playerCamera;

        private void Awake()
        {
            playerCamera = Camera.main;

            if (weaponPickup == null)
            {
                weaponPickup =
                    GetComponent<PlayerWeaponPickup>();
            }
        }

        public bool TryPickUpWeapon()
        {
            if (playerCamera == null ||
                weaponPickup == null)
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

            WeaponPickup pickup =
                hit.collider.GetComponentInParent<WeaponPickup>();

            if (pickup == null)
                return false;

            return weaponPickup.PickUpWeapon(pickup);
        }
    }
}
