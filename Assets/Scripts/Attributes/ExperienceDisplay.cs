using TMPro;
using UnityEngine;

namespace RPG.Attributes
{
    public class ExperienceDisplay : MonoBehaviour
    {
        Experience experience;

        private void Awake()
        {
            experience = GameObject.FindGameObjectWithTag("Player").GetComponent<Experience>();
        }
        private void Update()
        {
            GetComponent<TextMeshProUGUI>().text = experience.GetExperiencePoint().ToString(); ;
        }
    }
}
