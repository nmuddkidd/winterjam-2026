using UnityEngine;

public class reflect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject mirrorcam;
    public GameObject mirror;
    public char axis = 'z';
    private Vector3 initialpos;
    void Start()
    {
        initialpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        transform.rotation = mirrorcam.transform.rotation;

        //tests if player is looking toward mirror, if not inverts the camera for multilayer reflections
        if(Vector3.Angle(mirror.transform.position - mirrorcam.transform.position, transform.forward) > 80)
        {  
            //Debug.Log(mirror.transform.position - mirrorcam.transform.position);
            //Debug.Log(transform.eulerAngles);
            //Debug.Log(name+" is being inverted Angle is:" + Vector3.Angle(mirror.transform.position - mirrorcam.transform.position, transform.forward));
            Vector3 yrot = transform.eulerAngles;
            yrot.y+=180;
            transform.eulerAngles = yrot;
        }

        //chooses axis of reflection for the camera
        switch (axis){
            case 'x':
                mirrorX();
                break;
            case 'z':
                mirrorZ();
                break;
        }
    }

    void mirrorX()
    {
        //changes the cameras position based on the change of the players position from its corresponding mirror
        Vector3 newpos = initialpos + (mirrorcam.transform.position - mirror.transform.position);
        //keeps camera on same plane as mirror (x plane)
        newpos.x = initialpos.x;
        transform.position = newpos;
    }

    void mirrorZ()
    {
        //changes the cameras position based on the change of the players position from its corresponding mirror
        Vector3 newpos = initialpos + (mirrorcam.transform.position - mirror.transform.position);
        //keeps camera on same plane as mirror (z plane)
        newpos.z = initialpos.z;
        transform.position = newpos;
    }
}
