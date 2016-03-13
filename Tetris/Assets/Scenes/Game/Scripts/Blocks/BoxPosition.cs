using UnityEngine;
using System.Collections;

/*
 *  Keeps track of the position of box that is inserted into an array
 *  Knows the rotation pivot (offset)
 */
public class BoxPosition : MonoBehaviour {

    public int arrayPosX = 0;
    public int arrayPosY = 0;

    public int offSetX = 0;
    public int offSetY = 0;

    void Start ()
    {
        transform.localPosition = new Vector3(offSetX,offSetY);
    }

    public void setArrayPositions(int parentArrayX, int parentArrayY)
    {
        arrayPosX = parentArrayX + offSetX;
        arrayPosY = parentArrayY + offSetY;
    }
}
