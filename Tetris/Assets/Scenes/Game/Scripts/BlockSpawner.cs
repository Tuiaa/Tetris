﻿using UnityEngine;
using System.Collections;

/*
 *  Spawns blocks
 */
public class BlockSpawner : MonoBehaviour
{
    public GameObject grid;
    public GameObject[] blocks;
    public GameObject block;
    public GameController gameController;
    
    bool firstBlock = false;
    
    int next;

    float height;
    float width;

    public void spawnBlock()
    {
        int current;
        current = Random.Range(0, 6);
        Grid gr = grid.GetComponent<Grid>();
        
        block = Instantiate(blocks[current], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        int blockOffset = block.GetComponent<CurrentBlock>().startYOffset;
        int spawnPosX = gr.gridWidth / 2;
        int spawnPosY = gr.gridHeight - 1 + blockOffset;

        grid.GetComponent<Grid>().setUnityPosition(block, spawnPosX, spawnPosY);
        block.GetComponent<CurrentBlock>().setArrayPositions(spawnPosX, spawnPosY);
       
        grid.GetComponent<Grid>().currentBlock = block;
        block.name = "CurrentBlock";

        block.transform.parent = transform;

        bool canSpawn = grid.GetComponent<Grid>().checkRotation();
        if (canSpawn == false)
        {
            gameController.GetComponent<GameController>().gameEnded = true;
        }
        //block.GetComponent<I_BlockBox_Position>().setStartPositions();
        //firstBlock = true;

        /* else
         {
             block = Instantiate(blocks[0], new Vector3(0.5F, spawnPosY, -0.5F), Quaternion.identity) as GameObject;
             block.transform.parent = transform;

             next = Random.Range(0, 6);
             current = next;
         }*/
    }

    bool checkIfNewBlockCanSpawn(GameObject block)
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            GameObject child = block.transform.GetChild(i).gameObject;
            int posX = child.GetComponent<BoxPosition>().arrayPosX;
            int posY = child.GetComponent<BoxPosition>().arrayPosY;

            if (grid.GetComponent<Grid>().blockPositions[posX, posY] != null)
            {
                return false;
            }
            else
            {
                
                return true;
            }
        }
        return false;
    }
}
