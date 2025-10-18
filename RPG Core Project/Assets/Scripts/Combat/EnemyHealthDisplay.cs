using UnityEngine;
using TMPro;
using RPG.Attributes;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter;

        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }
        private void Update()
        {
            if (fighter.GetTarget() == null)
            {
                GetComponent<TextMeshProUGUI>().SetText("N/A");
                return;
            }
            Health health = fighter.GetTarget();
            GetComponent<TextMeshProUGUI>().SetText("{0:0.0}%", health.GetPercentage());
        }
    }
}