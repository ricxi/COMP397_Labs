using UnityEngine;
using UnityEngine.InputSystem;
using KBCore.Refs;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour
{
    private InputAction _move;
    private InputAction _look;
    private Vector3 _velocity;

    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -30.0f;
    [SerializeField] private float rotationSpeed = 4.0f;
    [SerializeField] private float mouseSensY = 5.0f;
    [SerializeField] private Camera cam;
    [SerializeField, Self] private CharacterController controller;

    private void OnValidate()
    {
        this.ValidateRefs();
    }

    void Start()
    {
        _move = InputSystem.actions.FindAction("Player/Move");
        _look = InputSystem.actions.FindAction("Player/Look");
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 readMove = _move.ReadValue<Vector2>();
        Vector2 readLook = _look.ReadValue<Vector2>();

        // Player Movement
        Vector3 movement = transform.right * readMove.x + transform.forward * readMove.y;
        _velocity.y += gravity * Time.deltaTime;
        movement *= maxSpeed * Time.deltaTime;
        movement += _velocity;
        controller.Move(movement);

        // Player Rotation
        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);

        // Camera Rotation
        mouseSensY = mouseSensY * readLook.y;
        mouseSensY = Mathf.Clamp(mouseSensY, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(mouseSensY, 0, 0);
    }
}
