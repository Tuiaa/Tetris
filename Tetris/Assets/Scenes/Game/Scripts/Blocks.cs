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
}
