using TMPro;
using UnityEngine;

namespace RPG.UI.DamageText
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;
        public void DestroyText()
        {
            Destroy(gameObject);
        }
        public void SetValue(float amount)
        {
            text.text = amount.ToString("f2");
        }
    }
}
