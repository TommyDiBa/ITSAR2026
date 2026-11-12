using UnityEngine;

public class PlayerControllRigidBody : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    private GameControls controls;
    private float force = 50f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new GameControls();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();
    private void OnDestroy() => controls.Dispose();


    private void Update()       // ogni frame: leggo
    {
        input = controls.Player.Move.ReadValue<Vector2>();
        Debug.Log(input);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(input.x, 0f, input.y) * force);

        Vector3 input3 = new Vector3(input.x, 0f, input.y);
        Vector3 velocity = input3 * force;

        rb.MovePosition(rb.position + input3 * force);
    }


}
