using UnityEngine;

public class follower : MonoBehaviour
{
    public GameObject target;
    public GameObject stare;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;
        if(stare!=null){
            transform.LookAt(stare.transform.position);
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y+90,0);
        }
        else
        {
            transform.rotation = target.transform.rotation;
        }
    }
}
