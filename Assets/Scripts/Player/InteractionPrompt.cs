using UnityEngine;
using UnityEngine.Events;

namespace StrikeZone.Player
{
    public class InteractionPrompt : MonoBehaviour
    {
        [Header("Interaction")]
        [SerializeField] private float interactionRange = 3f;
        [SerializeField] private LayerMask interactionLayers = ~0;

        [Header("Events")]
        [SerializeField] private UnityEvent onWeaponDetected;
        [SerializeField] private UnityEvent onAmmoDetected;
        [SerializeField] private UnityEvent onNothingDetected;

        private Camera playerCamera;

        public bool IsWeaponAvailable { get; private set; }
        public bool IsAmmoAvailable { get; private set; }

        private void Awake()
        {
            playerCamera = Camera.main;
        }

        private void Update()
        {
            DetectInteraction();
        }

        private void DetectInteraction()
        {
            IsWeaponAvailable = false;
            IsAmmoAvailable = false;

            if (playerCamera == null)
                return;

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
                onNothingDetected?.Invoke();
                return;
            }

            if (hit.collider.GetComponentInParent<
                    Weapons.WeaponPickup>() != null)
            {
                IsWeaponAvailable = true;
                onWeaponDetected?.Invoke();
                return;
            }

            if (hit.collider.GetComponentInParent<
                    Weapons.AmmoPickup>() != null)
            {
                IsAmmoAvailable = true;
                onAmmoDetected?.Invoke();
                return;
            }

            onNothingDetected?.Invoke();
        }
    }
}
