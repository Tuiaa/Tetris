using UnityEngine;

/*
 *  Keeps track of the position of box that is inserted into an array
 *  Knows the rotation point (offset)
 */
public class BoxPosition : MonoBehaviour
{

    public int arrayPosX = 0;
    public int arrayPosY = 0;

    public int offSetX = 0;
    public int offSetY = 0;

    void Start()
    {
        transform.localPosition = new Vector3(offSetX, offSetY);
    }

    public void setArrayPositions(int parentArrayX, int parentArrayY)
    {
        arrayPosX = parentArrayX + offSetX;
        arrayPosY = parentArrayY + offSetY;
    }

    public void setOffset(int xOffSet, int yOffSet)
    {
        offSetX = xOffSet;
        offSetY = yOffSet;
    }

    public void moveBox(Grid.Directions dir, int amount)
    {
        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        if (dir == Grid.Directions.DOWN)
        {
            arrayPosY = arrayPosY - amount;
        }
        if (dir == Grid.Directions.UP)
        {
            arrayPosY = arrayPosY + amount;
        }
        if (dir == Grid.Directions.LEFT)
        {
            arrayPosX = arrayPosX - amount;
        }
        if (dir == Grid.Directions.RIGHT)
        {
            arrayPosX = arrayPosX + amount;
        }
        grid.setUnityPosition(gameObject, arrayPosX, arrayPosY);
    }
}
