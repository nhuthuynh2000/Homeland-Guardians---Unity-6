using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        bool isDead = false;

        public bool IsDead { get => isDead; }
        public void TakeDamage(float amountDamage)
        {
            health = Mathf.Max(health - amountDamage, 0);
            print(health);
            if (!isDead && health == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }

}