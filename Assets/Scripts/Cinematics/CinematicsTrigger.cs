using RPG.Saving;
using UnityEngine;
using UnityEngine.Playables;
namespace RPG.Cinematics
{
    public class CinematicsTrigger : MonoBehaviour, ISaveable
    {
        static bool hasTriggered = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!hasTriggered && other.gameObject.CompareTag("Player"))
            {
                GetComponent<PlayableDirector>().Play();
                hasTriggered = true;
            }
        }

        public object CaptureState()
        {
            return hasTriggered;
        }

        public void RestoreState(object state)
        {
            hasTriggered = (bool)state;
        }
    }
}
