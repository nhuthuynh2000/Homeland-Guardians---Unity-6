using TMPro;
using UnityEngine;

namespace RPG.Stats
{
    public class LevelDisplay : MonoBehaviour
    {
        BaseStats baseStats;

        private void Awake()
        {
            baseStats = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseStats>();
        }
        private void Update()
        {
            GetComponent<TextMeshProUGUI>().text = baseStats.GetLevel().ToString(); ;
        }
    }
}
