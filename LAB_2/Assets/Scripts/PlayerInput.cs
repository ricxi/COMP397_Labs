using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    private InputAction _move;
    private InputAction _look;
    [SerializeField] private CharacterController controller;

    void Start()
    {
        _move = InputSystem.actions.FindAction("Player/Move");
        _look = InputSystem.actions.FindAction("Player/Look");
        controller = GetComponent<CharacterController>();
        // // or use RequireCompoment instead
        // if (controller == null)
        // {
        //     controller = gameObject.AddComponent<CharacterController>();
        // }
    }

    void Update()
    {
        Vector2 readMove = _move.ReadValue<Vector2>();
        Vector2 readLook = _look.ReadValue<Vector2>();
        Debug.Log(readMove);
        Debug.Log(readLook);
    }
}
