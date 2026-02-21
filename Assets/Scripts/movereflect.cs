using UnityEngine;

public class movereflect : MonoBehaviour
{
    public GameObject mirroredobj;
    public char axis = 'z';
    private Vector3 initialpos;
    private Vector3 parentinitialpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //saves the initial position of the model and the player
        initialpos = transform.position;
        parentinitialpos = mirroredobj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //chooses which reflection it is
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
        //updates the position by adding the initial position and the parents change, inverting the reflection axis
        Vector3 changeparent = mirroredobj.transform.position - parentinitialpos;
        Vector3 newpos = initialpos + changeparent;
        newpos.x -= 2*changeparent.x;
        transform.position = newpos;
    }

    void reflectZ()
    {
        //updates the position by adding the initial position and the parents change, inverting the reflection axis
        Vector3 changeparent = mirroredobj.transform.position - parentinitialpos;
        Vector3 newpos = initialpos + changeparent;
        newpos.z -= 2*changeparent.z;
        transform.position = newpos;
    }
}
