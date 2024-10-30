using UnityEngine;

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1, 100)]
        [SerializeField] int startingLevel = 1;
        [SerializeField] CharacterClass characterClass;
        [SerializeField] Progression progression;

        public float GetStats(Stats stat)
        {
            return progression.GetStats(stat, characterClass, startingLevel);
        }
    }
}
