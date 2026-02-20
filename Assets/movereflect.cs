using UnityEngine;

public class movereflect : MonoBehaviour
{
    public char axis = 'z';
    private Vector3 initialpos;
    private Vector3 parentinitialpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialpos = transform.position;
        parentinitialpos = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (axis)
        {
            case 'z':
                reflectZ();
                break;
            case 'x':
                reflectX();
                break;
        }
    }

    void reflectX()
    {
        Vector3 changeparent = transform.parent.position - parentinitialpos;
        Vector3 newpos = initialpos + changeparent;
        newpos.x -= 2*changeparent.x;
        transform.position = newpos;
    }

    void reflectZ()
    {
        Vector3 changeparent = transform.parent.position - parentinitialpos;
        Vector3 newpos = initialpos + changeparent;
        newpos.z -= 2*changeparent.z;
        transform.position = newpos;
    }
}
