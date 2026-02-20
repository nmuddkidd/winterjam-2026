using UnityEngine;

public class reflect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject mirrorcam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //vector pointing f
        transform.LookAt(mirrorcam.transform);
        Vector3 rotation = transform.eulerAngles;
        rotation.z += 180;
        transform.eulerAngles = rotation;

        Vector3 newposition = mirrorcam.transform.position;
        newposition.z = transform.position.z;
        transform.position = newposition;
        //transform.eulerAngles = Vector3.Reflect(mirrorcam.transform.eulerAngles, new Vector3(0,0,1));

    }
}
