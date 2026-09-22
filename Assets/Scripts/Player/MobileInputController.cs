using UnityEngine;

namespace StrikeZone.Player
{
    public class MobileInputController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private FPSCamera fpsCamera;

        private Vector2 movementInput;
        private Vector2 lookInput;

        private bool sprinting;
        private bool crouching;

        private void Awake()
        {
            if (playerController == null)
            {
                playerController =
                    GetComponent<PlayerController>();
            }
        }

        private void Update()
        {
            if (playerController != null)
            {
                playerController.SetMoveInput(
                    movementInput
                );

                playerController.SetSprint(
                    sprinting
                );

                playerController.SetCrouch(
                    crouching
                );
            }

            if (fpsCamera != null &&
                lookInput.sqrMagnitude > 0.0001f)
            {
                fpsCamera.Look(lookInput);
            }

            // Reset look input after each frame.
            lookInput = Vector2.zero;
        }

        public void SetMovement(Vector2 input)
        {
            movementInput =
                Vector2.ClampMagnitude(input, 1f);
        }

        public void SetLook(Vector2 input)
        {
            lookInput = input;
        }

        public void SetSprint(bool value)
        {
            sprinting = value;
        }

        public void SetCrouch(bool value)
        {
            crouching = value;
        }

        public void Jump()
        {
            if (playerController != null)
            {
                playerController.Jump();
            }
        }
    }
}
