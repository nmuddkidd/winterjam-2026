using UnityEngine;

public class movereflect : MonoBehaviour
{
    public GameObject player;
    public Rigidbody body; 
    private CharacterController controller;
    public float playerSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newvelocity = controller.velocity;
        //newvelocity.z *= -1;
        //body.linearVelocity = newvelocity;

        //mirror over z=33
        Vector3 newpos = player.transform.position;
        newpos.z = 33+(33 - player.transform.position.z);
        transform.position = newpos;
    }
}
