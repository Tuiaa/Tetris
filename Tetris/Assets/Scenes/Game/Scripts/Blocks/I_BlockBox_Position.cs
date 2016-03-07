using UnityEngine;
using System.Collections;

public class I_BlockBox_Position : MonoBehaviour {

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;

    public GameObject Grid;

    public int arrayPosX;
    public int arrayPosY;

    void Awake()
    {
        Grid = GameObject.Find("Grid");
    }

    public void setStartPositions () {

        arrayPosX = (Grid.GetComponent<Grid>().gridWidth / 2) + Grid.GetComponent<Grid>().gridWidth % 2;
        arrayPosY = Grid.GetComponent<Grid>().gridHeight - 1;

        box1.GetComponent<BoxPosition>().arrayPosX = arrayPosX;
        box1.GetComponent<BoxPosition>().arrayPosY = arrayPosY;


        box2.GetComponent<BoxPosition>().arrayPosX = arrayPosX;
        box2.GetComponent<BoxPosition>().arrayPosY = arrayPosY -1;

        box3.GetComponent<BoxPosition>().arrayPosX = arrayPosX;
        box3.GetComponent<BoxPosition>().arrayPosY = arrayPosY -2;

        box4.GetComponent<BoxPosition>().arrayPosX = arrayPosX;
        box4.GetComponent<BoxPosition>().arrayPosY = arrayPosY -3;

    }
}
