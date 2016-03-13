﻿using UnityEngine;
using System.Collections;

/*
 *  Moves blocks, updates their positions, ends game
 */
public class GameController : MonoBehaviour
{

    public GameObject spawner;
    public GameObject grid;
    public GameObject block;

    public int blockBoxPosX;
    public int blockBoxPosY;
    public int rotatedPosX;
    public int rotatedPosY;

    public float nextMove = 0.0F;
    public int movingSpeed = 1;

    void Start()
    {
        spawner = GameObject.Find("BlockSpawner");
        grid = GameObject.Find("Grid");

        nextMove = Time.time + 1.0F;
        spawner.GetComponent<BlockSpawner>().spawnBlock();
    }

    void Update()
    {
        block = GameObject.Find("CurrentBlock");

        if (Time.time > nextMove)
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.DOWN);
            if (canMove)
            {
                block.GetComponent<CurrentBlock>().moveBlock(Grid.Directions.DOWN, movingSpeed);
                nextMove = Time.time + movingSpeed;
            }
            else
            {
                grid.GetComponent<Grid>().moveToStuckBlocks();
                spawner.GetComponent<BlockSpawner>().spawnBlock();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.LEFT);
            if (canMove == true)
            {
                block.GetComponent<CurrentBlock>().moveBlock(Grid.Directions.LEFT, movingSpeed);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.RIGHT);
            if (canMove)
            {
                block.GetComponent<CurrentBlock>().moveBlock(Grid.Directions.RIGHT, movingSpeed);
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.DOWN);
            if (canMove)
            {
                block.GetComponent<CurrentBlock>().moveBlock(Grid.Directions.DOWN, movingSpeed);
            }
            else
            {
                grid.GetComponent<Grid>().moveToStuckBlocks();
                spawner.GetComponent<BlockSpawner>().spawnBlock();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotateBlock();
        }
    }

    // TODO: Move
    void updateBoxPositions(int posX, int posY)
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            GameObject child = block.transform.GetChild(i).gameObject;
            child.GetComponent<BoxPosition>().arrayPosX += posX;
            child.GetComponent<BoxPosition>().arrayPosY += posY;
        }
    }


    public void rotateBlock()
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            GameObject child = block.transform.GetChild(i).gameObject;

            int arrayPosX = child.GetComponent<BoxPosition>().arrayPosX;
            int arrayPosY = child.GetComponent<BoxPosition>().arrayPosY;

            int offSetX = child.GetComponent<BoxPosition>().offSetX;
            int offSetY = child.GetComponent<BoxPosition>().offSetY;

            rotatedPosX = (0 * offSetX) + (1 * offSetY);
            rotatedPosY = (-1 * offSetX) + (0 * offSetY);

            child.GetComponent<BoxPosition>().setOffset(rotatedPosX, rotatedPosY);

            block.GetComponent<CurrentBlock>().updateChildArrayPos();



            /*
             // bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.UP);
            bool canMove = true;
            if (canMove)
            {
        */
        }

        bool canRotate = grid.GetComponent<Grid>().checkRotation();

        if (canRotate)
        {
            for (int i = 0; i < block.transform.childCount; i++)
            {
                GameObject child = block.transform.GetChild(i).gameObject;

                int arrayPosX = child.GetComponent<BoxPosition>().arrayPosX;
                int arrayPosY = child.GetComponent<BoxPosition>().arrayPosY;



                grid.GetComponent<Grid>().setUnityPosition(child, child.GetComponent<BoxPosition>().arrayPosX, child.GetComponent<BoxPosition>().arrayPosY);
            }
        }
        else
        {
            for (int i = 0; i < block.transform.childCount; i++)
            {
                GameObject child = block.transform.GetChild(i).gameObject;
                int offSetX = child.GetComponent<BoxPosition>().offSetX;
                int offSetY = child.GetComponent<BoxPosition>().offSetY;

                rotatedPosX = (0 * offSetX) + (-1 * offSetY);
                rotatedPosY = (1 * offSetX) + (0 * offSetY);

                child.GetComponent<BoxPosition>().setOffset(rotatedPosX, rotatedPosY);

                block.GetComponent<CurrentBlock>().updateChildArrayPos();
            }
        }
    }
}
