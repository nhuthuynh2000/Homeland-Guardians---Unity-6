using RPG.Attributes;
using TMPro;
using UnityEngine;

namespace RPG.Attributes
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;

        private void Awake()
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }
        private void Update()
        {
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.0}%", health.GetPercentage());
        }
    }
}
