using UnityEngine;

namespace StrikeZone.Player
{
    public class InteractionButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GamePlayerInteractor interactor;

        private void Awake()
        {
            if (interactor == null)
            {
                interactor =
                    GetComponentInParent<GamePlayerInteractor>();
            }
        }

        public void PressInteract()
        {
            if (interactor == null)
                return;

            interactor.Interact();
        }
    }
}
