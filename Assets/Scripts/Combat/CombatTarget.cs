using UnityEngine;
using RPG.Core;
using RPG.Attributes;
using RPG.Controll;
namespace RPG.Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour, IRaycastable
    {
        public CursorType GetCursorType()
        {
            return CursorType.Combat;
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            if (!callingController.GetComponent<Fighter>().CanAttack(gameObject))
            {
                return false;
            }
            if (Input.GetMouseButton(1))
            {
                callingController.GetComponent<Fighter>().Attack(gameObject);
            }

            return true;
        }
    }
}
