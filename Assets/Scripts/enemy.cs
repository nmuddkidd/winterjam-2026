using UnityEngine;

public class enemy : MonoBehaviour
{
    public float movespeed = 3f;
    public GameObject player;
    public Rigidbody body;
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(player.transform.position);
        body.linearVelocity=transform.forward*movespeed*Time.deltaTime;
    }
}
