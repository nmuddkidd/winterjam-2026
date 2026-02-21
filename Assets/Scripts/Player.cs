using System;
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

    private GameObject[] pickups;
    public String[] reqitems = {"block1","block2","block3"};
    private bool[] pickedup = new bool[3];
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
        movement();
        clickinteraction();
    }

    void movement()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            // Slight downward velocity to keep grounded stable
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;
        }

        //rotation of playerbody
        pitch += Input.GetAxis("Mouse Y") * Ysens * -1;
        yaw += Input.GetAxis("Mouse X") * Xsens;
        transform.rotation = Quaternion.Euler(pitch,yaw,0);
        //(might want to make this only rotate the camera/ part of player the whole player model rotates as is)

        float xrotation = transform.eulerAngles.y * Mathf.PI/180;

        // Jump using WasPressedThisFrame()
        if (groundedPlayer && jumpAction.action.WasPressedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        
        //Control handling -- uses legacy input system -- could be updated to new input
        //when I programmed this only god and I knew how it worked, now only god knows
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
        //submits adjusted final move command to movement controller
        controller.Move(finalMove * Time.deltaTime);
    }

    void clickinteraction()
    {
        if (Input.GetMouseButtonDown(0)&&allitems())
        {
            Debug.Log("all done!");
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("not done yet :()");
        }
        pickups = GameObject.FindGameObjectsWithTag("pickup");
        foreach (GameObject pickup in pickups)
        {
            //Debug.Log(Vector3.Distance(transform.position, pickup.transform.position)+" "+Vector3.Angle(pickup.transform.position - transform.position, transform.forward));
            if(Input.GetMouseButtonDown(0)){
                if(Vector3.Distance(transform.position, pickup.transform.position)<5
                &&Vector3.Angle(pickup.transform.position - transform.position, transform.forward)<50)
                {
                    pickedup[Array.IndexOf(reqitems,pickup.name)] = true;
                    Debug.Log(reqitems[Array.IndexOf(reqitems,pickup.name)]+" picked up");
                    Destroy(pickup);
                }
            }
        }
    }

    bool allitems()
    {
        foreach(bool b in pickedup)
        {
            if(!b){
                return false;
            }
        }
        return true;
    }
}