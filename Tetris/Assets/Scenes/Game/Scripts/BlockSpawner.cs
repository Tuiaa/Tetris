﻿using UnityEngine;
using System.Collections;

/*
 *  Spawns blocks
 */
public class BlockSpawner : MonoBehaviour
{
    public GameObject Grid;
    public GameObject[] blocks;
    public GameObject block;
    

    bool firstBlock = false;
    int current;
    int next;

    float height;
    float width;

    void Start()
    {
       
        
    }

    public void spawnBlock()
    {
        float spawnPosY = (Grid.GetComponent<Grid>().gridHeight / 2);
        
        if (firstBlock == false)
        {
            current = Random.Range(0, 6);
            
            /* Check if grid size is odd or even */
            if (Grid.GetComponent<Grid>().gridWidth % 2 == 0 && Grid.GetComponent<Grid>().gridHeight % 2 == 0)
            {
                block = Instantiate(blocks[0], new Vector3(0.5F, spawnPosY, -0.5F), Quaternion.identity) as GameObject;
            }
            else if (Grid.GetComponent<Grid>().gridWidth % 2 == 0 && Grid.GetComponent<Grid>().gridHeight % 2 != 0)
            {
                block = Instantiate(blocks[0], new Vector3(0.5F, spawnPosY + 0.5F, -0.5F), Quaternion.identity) as GameObject;
            }
            else if (Grid.GetComponent<Grid>().gridWidth % 2 != 0 && Grid.GetComponent<Grid>().gridHeight % 2 == 0)
            {
                block = Instantiate(blocks[0], new Vector3(1.0F, spawnPosY, -0.5F), Quaternion.identity) as GameObject;
            }
            else if (Grid.GetComponent<Grid>().gridWidth % 2 != 0 && Grid.GetComponent<Grid>().gridHeight % 2 != 0)
            {
                block = Instantiate(blocks[0], new Vector3(1.0F, spawnPosY + 0.5F, -0.5F), Quaternion.identity) as GameObject;
            }




            block.name = "CurrentBlock";
            
            block.transform.parent = transform;
            block.GetComponent<I_BlockBox_Position>().setStartPositions();
            firstBlock = true;
        }
        else
        {
            block = Instantiate(blocks[current], new Vector3(0.5F, spawnPosY, -0.5F), Quaternion.identity) as GameObject;
            block.transform.parent = transform;

            next = Random.Range(0, 6);
            current = next;
        }
    }
}
