using UnityEngine;
using System.Collections;

/*
 *  Initializes the start positions of blocks
 *  Updates the positions of four boxes that create the block
 */
public class Blocks : MonoBehaviour
{
    public void updateBoxPositions(int posX, int posY)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<BoxPosition>().arrayPosX += posX;
            child.GetComponent<BoxPosition>().arrayPosY += posY;
        }
    }

    public void rotateLeftArrayPos()
    {
       /* box1.GetComponent<BoxPosition>().arrayPosX += -2;
        box1.GetComponent<BoxPosition>().arrayPosY += -1;

        box2.GetComponent<BoxPosition>().arrayPosX += -1;
        box2.GetComponent<BoxPosition>().arrayPosY += 0;

        box3.GetComponent<BoxPosition>().arrayPosX += 0;
        box3.GetComponent<BoxPosition>().arrayPosY += 1;

        box4.GetComponent<BoxPosition>().arrayPosX += 1;
        box4.GetComponent<BoxPosition>().arrayPosY += 2;*/
    }
}
