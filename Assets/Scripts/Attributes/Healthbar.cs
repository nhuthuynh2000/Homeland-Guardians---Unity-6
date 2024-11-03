using UnityEngine;

namespace RPG.Attributes
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] Health health = null;
        [SerializeField] RectTransform foreground = null;
        [SerializeField] Canvas rootCanvas = null;

        private void Update()
        {
            float x = health.GetFraction();
            if (Mathf.Approximately(x, 0) || Mathf.Approximately(x, 1))
            {
                rootCanvas.enabled = false;
                return;
            }
            rootCanvas.enabled = true;
            foreground.localScale = new Vector3(x, 1, 1);
        }
    }

}