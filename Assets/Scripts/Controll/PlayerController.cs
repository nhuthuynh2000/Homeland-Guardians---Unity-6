using UnityEngine;
using UnityEngine.InputSystem;
using RPG.Movement;
using RPG.Combat;
using RPG.Core;

namespace RPG.Controll
{
    public class PlayerController : MonoBehaviour
    {
        Mover mover;
        InputSystem_Actions inputActions;

        Health health;
        Ray lastRay;
        bool isClicked = false;
        private void Awake()
        {
            inputActions = new InputSystem_Actions();
            inputActions.Player.Move.performed += OnMove;
            inputActions.Player.Move.canceled += OnMove;
        }

        private void Start()
        {
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
            inputActions.Enable();
        }
        private void Update()
        {
            if (health.IsDead) return;

            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();
                if (combatTarget == null) continue;
                if (!GetComponent<Fighter>().CanAttack(combatTarget.gameObject)) continue;
                if (isClicked)
                {
                    GetComponent<Fighter>().Attack(combatTarget.gameObject);
                    isClicked = false;
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (isClicked)
                {
                    mover.StartMoveAction(hit.point, 1f);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                isClicked = true;
            }
            else if (context.canceled)
            {
                isClicked = false;
            }
        }


        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}
