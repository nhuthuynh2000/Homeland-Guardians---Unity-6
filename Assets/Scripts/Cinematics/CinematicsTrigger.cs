using UnityEngine;
using UnityEngine.Playables;
namespace RPG.Cinematics
{
    public class CinematicsTrigger : MonoBehaviour
    {
        bool hasTriggered = false;
        private void OnTriggerEnter(Collider other)
        {
            if (!hasTriggered && other.gameObject.CompareTag("Player"))
            {
                GetComponent<PlayableDirector>().Play();
                hasTriggered = true;
            }
        }
    }
}
