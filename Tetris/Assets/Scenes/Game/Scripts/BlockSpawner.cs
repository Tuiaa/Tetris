using UnityEngine;
using System.Collections;

/*
 *  Spawns blocks
 */
public class BlockSpawner : MonoBehaviour
{
    public GameObject grid;
    public GameObject[] blocks;
    public GameObject block;
    
    bool firstBlock = false;
    
    int next;

    float height;
    float width;

    public void spawnBlock()
    {
        
        int current;
        current = Random.Range(0, 6);
        Grid gr = grid.GetComponent<Grid>();

        block = Instantiate(blocks[0],new Vector3(0,0,0), Quaternion.identity) as GameObject;

        int blockOffset = block.GetComponent<I_BlockBox_Position>().startYOffset;
        int spawnPosX = gr.gridWidth / 2;
        int spawnPosY = gr.gridHeight - 1 + blockOffset;

        grid.GetComponent<Grid>().setUnityPosition(block, spawnPosX, spawnPosY);
        block.GetComponent<I_BlockBox_Position>().setArrayPositions(spawnPosX, spawnPosY);
        
        grid.GetComponent<Grid>().currentBlock = block;
        block.name = "CurrentBlock";

        block.transform.parent = transform;
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
}
