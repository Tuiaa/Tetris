using UnityEngine;
using System.Collections;

/*
 *  Sets each blocks starting positions
 */
public class I_BlockBox_Position : MonoBehaviour
{

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;

    public GameObject grid;

    public int arrayPosX;
    public int arrayPosY;

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
            grid.GetComponent<Grid>().setUnityPosition(gameObject,arrayPosX, arrayPosY);
        }
    }

    public void setStartPositions()
    {
        
        /*
        arrayPosX = (grid.GetComponent<Grid>().gridWidth / 2) + grid.GetComponent<Grid>().gridWidth % 2;
        arrayPosY = grid.GetComponent<Grid>().gridHeight - 2;

        box1.GetComponent<BoxPosition>().arrayPosX = arrayPosX;
        box1.GetComponent<BoxPosition>().arrayPosY = arrayPosY + 1;
        Debug.Log("eka offset asetetaan nyt ");
        box1.GetComponent<BoxPosition>().offSetX = 0;
        box1.GetComponent<BoxPosition>().offSetY = 1;
        Debug.Log("box1: x: " + box1.GetComponent<BoxPosition>().offSetX + " y: " + box1.GetComponent<BoxPosition>().offSetY);

        box2.GetComponent<BoxPosition>().arrayPosX = arrayPosX;
        box2.GetComponent<BoxPosition>().arrayPosY = arrayPosY;
        Debug.Log("toka offset asetetaan nyt ");
        box2.GetComponent<BoxPosition>().offSetX = 0;
        box2.GetComponent<BoxPosition>().offSetY = 0;
        Debug.Log("box2: x: " + box2.GetComponent<BoxPosition>().offSetX + " y: " + box2.GetComponent<BoxPosition>().offSetY);

        box3.GetComponent<BoxPosition>().arrayPosX = arrayPosX;
        box3.GetComponent<BoxPosition>().arrayPosY = arrayPosY - 1;
        Debug.Log("kolmas offset asetetaan nyt ");
        box3.GetComponent<BoxPosition>().offSetX = 0;
        box3.GetComponent<BoxPosition>().offSetY = - 1;
        Debug.Log("box3: x: " + box3.GetComponent<BoxPosition>().offSetX + " y: " + box3.GetComponent<BoxPosition>().offSetY);

        box4.GetComponent<BoxPosition>().arrayPosX = arrayPosX;
        box4.GetComponent<BoxPosition>().arrayPosY = arrayPosY - 2;
        Debug.Log("neljäs offset asetetaan nyt ");
        box4.GetComponent<BoxPosition>().offSetX = 0;
        box4.GetComponent<BoxPosition>().offSetY = - 2;
        Debug.Log("box4: x: " + box4.GetComponent<BoxPosition>().offSetX + " y: " + box4.GetComponent<BoxPosition>().offSetY);
        */
    }
}
