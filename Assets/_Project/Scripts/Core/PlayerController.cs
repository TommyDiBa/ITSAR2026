using System;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{

    [SerializeField] CharacterController characterController;
    [SerializeField] Transform cameraTransform;

    private GameControls controls;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float sprintMultiplier = 1.5f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float rotationSpeed = 720f;


    private void Awake() => controls = new GameControls();


    private void OnEnable() => controls.Player.Enable();


    private void OnDisable() => controls.Player.Disable();

    private void OnDestroy() => controls.Dispose();


    private void Update()
    {
        ApplyGravity();
        MoveCharacter();
        RotateToDirection();
    }

    void MoveCharacter() 
    {

        Vector2 input = controls.Player.Move.ReadValue<Vector2>();
        Debug.Log(input);


        float speed = moveSpeed;
        if (controls.Player.Sprint.IsPressed())
            speed *= sprintMultiplier;


        //Vector3 moveVector = new Vector3(input.x, 0, input.y) * speed;

        Vector3 moveVector = CameraRelative(input) * speed;

        characterController.Move(moveVector * Time.deltaTime);



    }


    void ApplyGravity()
    {
        float verticalVelocity = 0f;
        if (characterController.isGrounded)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity = -gravity;
        }

        Vector3 velocity = Vector3.up * verticalVelocity;
        characterController.Move(velocity * Time.deltaTime);

    }

    void RotateToDirection()
    {

        Vector2 directionRaw = controls.Player.Move.ReadValue<Vector2>();
        Vector3 direction = CameraRelative(directionRaw);

        if (direction.sqrMagnitude > 0.001f)
        {

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, targetRotation,
                rotationSpeed * Time.deltaTime);

        }


    }



    private Vector3 CameraRelative(Vector2 input)
    {

        if (cameraTransform == null)
            return new Vector3(input.x, 0f, input.y);

        Vector3 foward = cameraTransform.forward;
        foward.y = 0f;
        foward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        return Vector3.ClampMagnitude(
            foward * input.y + right * input.x, 1f);
    }




}
