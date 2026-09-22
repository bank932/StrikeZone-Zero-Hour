using UnityEngine;
using StrikeZone.Player;

namespace StrikeZone.Weapons
{
    public class InteractableAmmo : MonoBehaviour, IInteractable
    {
        [Header("Ammo")]
        [SerializeField] private AmmoPickup ammoPickup;

        private void Awake()
        {
            if (ammoPickup == null)
            {
                ammoPickup = GetComponent<AmmoPickup>();
            }
        }

        public string GetInteractionText()
        {
            if (ammoPickup == null)
                return "Pick Up Ammo";

            return "Pick Up Ammo +" +
                   ammoPickup.AmmoAmount;
        }

        public bool CanInteract()
        {
            return ammoPickup != null &&
                   ammoPickup.AmmoAmount > 0;
        }

        public bool Interact(GamePlayerInteractor interactor)
        {
            if (interactor == null ||
                ammoPickup == null)
            {
                return false;
            }

            AmmoInteraction ammoInteraction =
                interactor.GetComponent<AmmoInteraction>();

            if (ammoInteraction == null)
                return false;

            return ammoInteraction.TryPickUpAmmo();
        }
    }
}
