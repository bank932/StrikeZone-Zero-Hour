using UnityEngine;

namespace StrikeZone.Player
{
    public class PlayerReviveInteraction : MonoBehaviour
    {
        [Header("Revive Settings")]
        [SerializeField] private float reviveRange = 3f;
        [SerializeField] private float reviveDuration = 4f;
        [SerializeField] private LayerMask playerLayers = ~0;

        private PlayerReviveState target;
        private float reviveTimer;
        private bool reviving;

        public bool IsReviving => reviving;
        public float ReviveProgress =>
            reviveDuration <= 0f
                ? 1f
                : Mathf.Clamp01(
                    reviveTimer / reviveDuration
                );

        private void Update()
        {
            if (!reviving)
                return;

            if (target == null ||
                target.IsEliminated ||
                !target.IsDowned)
            {
                CancelRevive();
                return;
            }

            float distance = Vector3.Distance(
                transform.position,
                target.transform.position
            );

            if (distance > reviveRange)
            {
                CancelRevive();
                return;
            }

            reviveTimer += Time.deltaTime;

            if (reviveTimer >= reviveDuration)
            {
                CompleteRevive();
            }
        }

        public bool StartRevive(PlayerReviveState teammate)
        {
            if (teammate == null ||
                !teammate.IsDowned ||
                teammate.IsEliminated)
            {
                return false;
            }

            float distance = Vector3.Distance(
                transform.position,
                teammate.transform.position
            );

            if (distance > reviveRange)
                return false;

            target = teammate;
            reviveTimer = 0f;
            reviving = true;

            return true;
        }

        public void CancelRevive()
        {
            target = null;
            reviveTimer = 0f;
            reviving = false;
        }

        private void CompleteRevive()
        {
            if (target == null)
            {
                CancelRevive();
                return;
            }

            target.Revive();
            CancelRevive();
        }
    }
}
