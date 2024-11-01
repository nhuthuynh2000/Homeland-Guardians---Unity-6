using System;
using RPG.Core;
using RPG.Saving;
using RPG.Stats;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Attributes
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float regenerationPercentage = 70;
        float healthPoints = -1f;
        bool isDead = false;

        public bool IsDead { get => isDead; }

        private void Start()
        {
            GetComponent<BaseStats>().OnLevelUp += RegenerateHealth;
            if (healthPoints < 0)
            {
                healthPoints = GetComponent<BaseStats>().GetStats(Stats.Stats.Health);
            }
        }

        public void TakeDamage(GameObject instigator, float amountDamage)
        {
            print(gameObject.name + " took damage: " + amountDamage);
            healthPoints = Mathf.Max(healthPoints - amountDamage, 0);
            print(healthPoints);
            if (!isDead && healthPoints == 0)
            {
                Die();
                AwardExperience(instigator);
            }
        }
        public float GetHealthPoints()
        {
            return healthPoints;
        }
        public float GetMaxHealthPoints()
        {
            return GetComponent<BaseStats>().GetStats(Stats.Stats.Health);
        }

        public void RegenerateHealth()
        {
            float regenHealthPoints = GetComponent<BaseStats>().GetStats(Stats.Stats.Health) * regenerationPercentage / 100;
            healthPoints = Mathf.Max(healthPoints, regenHealthPoints);
        }


        public float GetPercentage()
        {
            return 100 * (healthPoints / GetComponent<BaseStats>().GetStats(Stats.Stats.Health));
        }
        private void Die()
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if (experience == null) return;
            experience.GainExperience(GetComponent<BaseStats>().GetStats(Stats.Stats.ExperienceReward));
        }

        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints = (float)state;
            if (healthPoints <= 0)
            {
                Die();
            }
        }
    }

}