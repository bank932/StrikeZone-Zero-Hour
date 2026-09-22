using UnityEngine;
using System;

namespace StrikeZone.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private float maxHealth = 100f;

        [Header("Armor")]
        [SerializeField] private float maxArmor = 100f;

        private float currentHealth;
        private float currentArmor;

        public float CurrentHealth => currentHealth;
        public float CurrentArmor => currentArmor;

        public float HealthPercent =>
            maxHealth <= 0f ? 0f : currentHealth / maxHealth;

        public float ArmorPercent =>
            maxArmor <= 0f ? 0f : currentArmor / maxArmor;

        public bool IsDead => currentHealth <= 0f;

        public event Action<float, float> HealthChanged;
        public event Action<float, float> ArmorChanged;
        public event Action Died;

        private void Awake()
        {
            currentHealth = maxHealth;
            currentArmor = maxArmor;
        }

        public void TakeDamage(float damage)
        {
            if (IsDead || damage <= 0f)
                return;

            float armorDamage = Mathf.Min(
                currentArmor,
                damage
            );

            currentArmor -= armorDamage;

            float remainingDamage =
                damage - armorDamage;

            if (remainingDamage > 0f)
            {
                currentHealth = Mathf.Max(
                    0f,
                    currentHealth - remainingDamage
                );
            }

            ArmorChanged?.Invoke(
                currentArmor,
                maxArmor
            );

            HealthChanged?.Invoke(
                currentHealth,
                maxHealth
            );

            if (IsDead)
            {
                Died?.Invoke();
            }
        }

        public void Heal(float amount)
        {
            if (IsDead || amount <= 0f)
                return;

            currentHealth = Mathf.Min(
                maxHealth,
                currentHealth + amount
            );

            HealthChanged?.Invoke(
                currentHealth,
                maxHealth
            );
        }

        public void AddArmor(float amount)
        {
            if (IsDead || amount <= 0f)
                return;

            currentArmor = Mathf.Min(
                maxArmor,
                currentArmor + amount
            );

            ArmorChanged?.Invoke(
                currentArmor,
                maxArmor
            );
        }

        public void ResetHealth()
        {
            currentHealth = maxHealth;
            currentArmor = maxArmor;

            HealthChanged?.Invoke(
                currentHealth,
                maxHealth
            );

            ArmorChanged?.Invoke(
                currentArmor,
                maxArmor
            );
        }
    }
}
