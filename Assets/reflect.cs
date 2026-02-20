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
        //vector pointing f
        //transform.LookAt(mirrorcam.transform);
        //Vector3 rotation = transform.eulerAngles;
        //rotation.z += 180;
        //transform.eulerAngles = rotation;

        //transform.eulerAngles = Vector3.Reflect(mirrorcam.transform.eulerAngles, new Vector3(0,0,1));

        transform.rotation = mirrorcam.transform.rotation;

        if(Vector3.Angle(mirror.transform.position - mirrorcam.transform.position, transform.forward) > 80)
        {  
            Debug.Log(mirror.transform.position - mirrorcam.transform.position);
            Debug.Log(transform.eulerAngles);
            Debug.Log(name+" is being inverted Angle is:" + Vector3.Angle(mirror.transform.position - mirrorcam.transform.position, transform.forward));
            Vector3 yrot = transform.eulerAngles;
            yrot.y+=180;
            transform.eulerAngles = yrot;
        }

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
        Vector3 newpos = initialpos + (mirrorcam.transform.position - mirror.transform.position);//transform.parent.position);
        newpos.x = initialpos.x;
        transform.position = newpos;
    }

    void mirrorZ()
    {
        Vector3 newpos = initialpos + (mirrorcam.transform.position - mirror.transform.position);//transform.parent.position);
        newpos.z = initialpos.z;
        transform.position = newpos;
    }
}
