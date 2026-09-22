using UnityEngine;
using StrikeZone.Player;

namespace StrikeZone.Weapons
{
    public class InteractableWeapon : MonoBehaviour, IInteractable
    {
        [Header("Weapon")]
        [SerializeField] private WeaponPickup weaponPickup;

        private void Awake()
        {
            if (weaponPickup == null)
            {
                weaponPickup = GetComponent<WeaponPickup>();
            }
        }

        public string GetInteractionText()
        {
            if (weaponPickup == null ||
                weaponPickup.WeaponData == null)
            {
                return "Pick Up Weapon";
            }

            return "Pick Up " +
                   weaponPickup.WeaponData.weaponName;
        }

        public bool CanInteract()
        {
            return weaponPickup != null &&
                   weaponPickup.CanCollect();
        }

        public bool Interact(GamePlayerInteractor interactor)
        {
            if (interactor == null ||
                weaponPickup == null)
            {
                return false;
            }

            PlayerWeaponPickup playerPickup =
                interactor.GetComponent<PlayerWeaponPickup>();

            if (playerPickup == null)
            {
                return false;
            }

            return playerPickup.PickUpWeapon(
                weaponPickup
            );
        }
    }
}
