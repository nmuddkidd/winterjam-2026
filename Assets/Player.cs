using UnityEngine;
using UnityEngine.InputSystem;

public class Example : MonoBehaviour
{
    [Header("Movement Control")]
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;

    [Header("Camera Control")]
    public float Xsens = 10f;
    public float Ysens = 10f;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    private float yaw;
    private float pitch;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            // Slight downward velocity to keep grounded stable
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;
        }

        // Read input
        //Vector2 input = moveAction.action.ReadValue<Vector2>();
        //Vector3 move = new Vector3(input.x, 0, input.y);
        //move = Vector3.ClampMagnitude(move, 1f);

        //rotation of playerbody
        pitch += Input.GetAxis("Mouse Y") * Ysens * -1;
        yaw += Input.GetAxis("Mouse X") * Xsens;
        transform.rotation = Quaternion.Euler(pitch,yaw,0);

        float xrotation = transform.eulerAngles.y * Mathf.PI/180;

        // Jump using WasPressedThisFrame()
        if (groundedPlayer && jumpAction.action.WasPressedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Move
        //Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        //controller.Move(finalMove * Time.deltaTime);
        
        //Control handling
        Vector3 finalMove = new Vector3(0,playerVelocity.y,0);
        if (Input.GetKey(KeyCode.W)){
            finalMove = new Vector3(playerSpeed * Mathf.Sin(xrotation), playerVelocity.y, playerSpeed * Mathf.Cos(xrotation));
        }else if (Input.GetKey(KeyCode.S)){
            finalMove = new Vector3(-1 * playerSpeed * Mathf.Sin(xrotation), playerVelocity.y, -1 * playerSpeed * Mathf.Cos(xrotation));
        }if (Input.GetKey(KeyCode.A)){
            finalMove = new Vector3(-1 * playerSpeed * Mathf.Cos(xrotation), playerVelocity.y, playerSpeed * Mathf.Sin(xrotation));
        }else if (Input.GetKey(KeyCode.D)){
            finalMove = new Vector3(playerSpeed * Mathf.Cos(xrotation), playerVelocity.y, -1 * playerSpeed * Mathf.Sin(xrotation));
        }
        controller.Move(finalMove * Time.deltaTime);
    }
}