using UnityEngine;

namespace StrikeZone.Player
{
    public class GamePlayerInteractor : MonoBehaviour
    {
        [Header("Interaction")]
        [SerializeField] private float interactionRange = 3f;
        [SerializeField] private LayerMask interactionLayers = ~0;

        private Camera playerCamera;

        public IInteractable CurrentInteractable { get; private set; }

        private void Awake()
        {
            playerCamera = Camera.main;
        }

        private void Update()
        {
            FindInteractable();
        }

        private void FindInteractable()
        {
            CurrentInteractable = null;

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
                return;
            }

            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            if (interactable == null)
                return;

            if (!interactable.CanInteract())
                return;

            CurrentInteractable = interactable;
        }

        public bool Interact()
        {
            if (CurrentInteractable == null)
                return false;

            return CurrentInteractable.Interact(this);
        }

        public string GetInteractionText()
        {
            if (CurrentInteractable == null)
                return string.Empty;

            return CurrentInteractable.GetInteractionText();
        }
    }
}
