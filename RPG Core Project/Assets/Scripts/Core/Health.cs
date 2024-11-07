using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;

namespace RPG.Core
{

    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float healthPoints = 100f;

        bool isDead = false;

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
