﻿using UnityEngine;
using System.Collections;

public class I_BlockBox_Position : MonoBehaviour {

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;

    public GameObject grid;

    public int arrayPosX;
    public int arrayPosY;

    void Awake()
    {
        grid = GameObject.Find("Grid");
    }

    public void setStartPositions () {

        arrayPosX = (grid.GetComponent<Grid>().gridWidth / 2) + grid.GetComponent<Grid>().gridWidth % 2;
        arrayPosY = grid.GetComponent<Grid>().gridHeight - 1;

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
