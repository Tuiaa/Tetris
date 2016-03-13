using UnityEngine;
using System.Collections;

/*
 *  Sets each blocks starting positions
 */
public class CurrentBlock : MonoBehaviour
{
    public GameObject grid;

    public int arrayPosX;
    public int arrayPosY;

    public bool canBlockRotate = true;

    public int startYOffset = 0;

    void Awake()
    {
        grid = GameObject.Find("Grid");
    }

    void Start()
    {
    }

    public void setArrayPositions(int xArray, int yArray)
    {
        arrayPosX = xArray;
        arrayPosY = yArray;
        updateChildArrayPos();
    }

    public void updateChildArrayPos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<BoxPosition>().setArrayPositions(arrayPosX, arrayPosY);
        }
    }

    public void moveBlock(Grid.Directions direction, int amount)
    {
        // Down Grid.Direction
        if (direction == Grid.Directions.DOWN)
        {
            arrayPosY = arrayPosY - amount;
            updateChildArrayPos();
            grid.GetComponent<Grid>().setUnityPosition(gameObject, arrayPosX, arrayPosY);
        }
        else if (direction == Grid.Directions.LEFT)
        {
            arrayPosX = arrayPosX - amount;
            updateChildArrayPos();
            grid.GetComponent<Grid>().setUnityPosition(gameObject, arrayPosX, arrayPosY);
        }
        else if (direction == Grid.Directions.RIGHT)
        {
            arrayPosX = arrayPosX + amount;
            updateChildArrayPos();
            grid.GetComponent<Grid>().setUnityPosition(gameObject, arrayPosX, arrayPosY);
        }
    }
}
