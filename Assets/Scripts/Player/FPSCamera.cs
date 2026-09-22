using UnityEngine;

namespace StrikeZone.Player
{
    public class FPSCamera : MonoBehaviour
    {
        [Header("Look Settings")]
        [SerializeField] private float sensitivity = 150f;
        [SerializeField] private float minPitch = -80f;
        [SerializeField] private float maxPitch = 80f;

        private float pitch;
        private Transform player;

        private void Awake()
        {
            player = transform.parent;
        }

        public void Look(Vector2 input)
        {
            float yaw =
                input.x * sensitivity * Time.deltaTime;

            float pitchInput =
                input.y * sensitivity * Time.deltaTime;

            pitch -= pitchInput;

            pitch = Mathf.Clamp(
                pitch,
                minPitch,
                maxPitch
            );

            transform.localRotation =
                Quaternion.Euler(
                    pitch,
                    0f,
                    0f
                );

            if (player != null)
            {
                player.Rotate(
                    Vector3.up * yaw
                );
            }
        }

        public void SetSensitivity(float value)
        {
            sensitivity = Mathf.Max(1f, value);
        }
    }
}
