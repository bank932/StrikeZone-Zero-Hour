using UnityEngine;

namespace StrikeZone.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float sprintSpeed = 8f;
        [SerializeField] private float crouchSpeed = 2.5f;
        [SerializeField] private float jumpHeight = 1.3f;

        [Header("Gravity")]
        [SerializeField] private float gravity = -20f;

        [Header("References")]
        [SerializeField] private Transform cameraTransform;

        private CharacterController controller;
        private Vector2 moveInput;
        private float verticalVelocity;

        private bool sprinting;
        private bool crouching;

        public bool IsSprinting => sprinting;
        public bool IsCrouching => crouching;
        public bool IsGrounded => controller != null && controller.isGrounded;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();

            if (cameraTransform == null && Camera.main != null)
            {
                cameraTransform = Camera.main.transform;
            }
        }

        private void Update()
        {
            HandleMovement();
        }

        public void SetMoveInput(Vector2 input)
        {
            moveInput = Vector2.ClampMagnitude(input, 1f);
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
            if (!controller.isGrounded)
                return;

            verticalVelocity = Mathf.Sqrt(
                jumpHeight * -2f * gravity
            );
        }

        private void HandleMovement()
        {
            if (controller.isGrounded && verticalVelocity < 0f)
            {
                verticalVelocity = -2f;
            }

            Vector3 forward = cameraTransform != null
                ? cameraTransform.forward
                : transform.forward;

            Vector3 right = cameraTransform != null
                ? cameraTransform.right
                : transform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            Vector3 direction =
                forward * moveInput.y +
                right * moveInput.x;

            float speed = walkSpeed;

            if (crouching)
            {
                speed = crouchSpeed;
            }
            else if (sprinting && moveInput.y > 0.1f)
            {
                speed = sprintSpeed;
            }

            controller.Move(
                direction * speed * Time.deltaTime
            );

            verticalVelocity += gravity * Time.deltaTime;

            controller.Move(
                Vector3.up *
                verticalVelocity *
                Time.deltaTime
            );
        }
    }
}
