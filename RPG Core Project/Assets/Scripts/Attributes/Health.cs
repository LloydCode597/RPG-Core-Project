using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;
using RPG.Core;
using RPG.Stats;

namespace RPG.Attributes
{

    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoints = 100f;

        bool isDead = false;

        private void Start()
        {
            healthPoints = GetComponent<BaseStats>().GetHealth();
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if (healthPoints == 0)
            {
                Die();
            }
        }

        public float GetPercentage()
        {
            return 100 * (healthPoints / GetComponent<BaseStats>().GetHealth());
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        public object CaptureState()
        {
            return healthPoints;
        }
        public void RestoreState(object state)
        {
            healthPoints = (float)state;

            // Check if the enemy should be "alive" or "dead" based on restored health points
            if (healthPoints <= 0)
            {
                Die();
            }
            // else
            // {
            //     // Reset `isDead` to false if the enemy is restored with health
            //     isDead = false;
            //     GetComponent<Animator>().ResetTrigger("die");
            //     GetComponent<Animator>().Play("Idle"); // Adjust to the appropriate idle or starting animation
            // }
        }
    }
}
