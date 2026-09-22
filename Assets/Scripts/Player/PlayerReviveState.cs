using System;
using UnityEngine;

namespace StrikeZone.Player
{
    public class PlayerReviveState : MonoBehaviour
    {
        [Header("Downed State")]
        [SerializeField] private float bleedOutTime = 30f;

        private float bleedOutTimer;
        private bool isDowned;
        private bool isEliminated;

        public bool IsDowned => isDowned;
        public bool IsEliminated => isEliminated;
        public float BleedOutTimer => bleedOutTimer;

        public event Action Downed;
        public event Action Revived;
        public event Action Eliminated;

        private void Update()
        {
            if (!isDowned || isEliminated)
                return;

            bleedOutTimer -= Time.deltaTime;

            if (bleedOutTimer <= 0f)
            {
                bleedOutTimer = 0f;
                Eliminate();
            }
        }

        public void EnterDownedState()
        {
            if (isDowned || isEliminated)
                return;

            isDowned = true;
            bleedOutTimer = Mathf.Max(0f, bleedOutTime);

            Downed?.Invoke();
        }

        public void Revive()
        {
            if (!isDowned || isEliminated)
                return;

            isDowned = false;
            bleedOutTimer = 0f;

            Revived?.Invoke();
        }

        public void Eliminate()
        {
            if (isEliminated)
                return;

            isDowned = false;
            isEliminated = true;
            bleedOutTimer = 0f;

            Eliminated?.Invoke();
        }

        public void ResetState()
        {
            isDowned = false;
            isEliminated = false;
            bleedOutTimer = 0f;
        }
    }
}
