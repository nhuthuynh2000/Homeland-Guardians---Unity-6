using UnityEngine;
using UnityEngine.InputSystem;
using RPG.Movement;
using RPG.Combat;
using RPG.Core;
using RPG.Attributes;
using UnityEngine.InputSystem.LowLevel;
using System;
using System.Data;
using UnityEngine.EventSystems;

namespace RPG.Controll
{
    public class PlayerController : MonoBehaviour
    {
        enum CursorType
        {
            None,
            Movement,
            Combat,
            UI
        }
        [System.Serializable]
        struct CursorMapping
        {
            public CursorType type;
            public Texture2D texture;
            public Vector2 hotspot;
        }
        [SerializeField] CursorMapping[] cursorMappings = null;
        Mover mover;
        Fighter fighter;
        InputSystem_Actions inputActions;

        Health health;
        Ray lastRay;
        bool isClicked = false;
        private void Awake()
        {
            inputActions = new InputSystem_Actions();
            inputActions.Player.Move.performed += OnMove;
            inputActions.Player.Move.canceled += OnMove;
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
            fighter = GetComponent<Fighter>();
        }

        private void OnEnable()
        {
            inputActions.Enable();

        }
        private void Start()
        {

        }
        private void Update()
        {
            if (InteractWithUI())
            {
                SetCursor(CursorType.UI);
                return;
            }
            if (health.IsDead)
            {
                SetCursor(CursorType.None);
                return;
            }

            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;

            SetCursor(CursorType.None);
        }

        private bool InteractWithUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget combatTarget = hit.transform.GetComponent<CombatTarget>();
                if (combatTarget == null) continue;
                if (!fighter.CanAttack(combatTarget.gameObject)) continue;
                if (isClicked)
                {
                    fighter.Attack(combatTarget.gameObject);
                    isClicked = false;
                }
                SetCursor(CursorType.Combat);
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
                SetCursor(CursorType.Movement);
                return true;
            }
            return false;
        }
        private void SetCursor(CursorType type)
        {
            CursorMapping mapping = GetCursorMapping(type);
            Cursor.SetCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
        }

        private CursorMapping GetCursorMapping(CursorType type)
        {
            foreach (CursorMapping mapping in cursorMappings)
            {
                if (mapping.type == type)
                {
                    return mapping;
                }
            }
            return cursorMappings[0];
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
