using UnityEngine;
using System.Collections;

/*
 *  Spawns blocks, checks if can spawn any more blocks
 */
public class BlockSpawner : MonoBehaviour
{
    public GameObject grid;
    public GameObject[] blocks;
    public GameObject block;
    public GameController gameController;

    float height;
    float width;

    public void spawnBlock()
    {
        int current = Random.Range(0, 6);
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

        /* Check if block can spawn */
        bool canSpawn = grid.GetComponent<Grid>().checkRotation();
        if (canSpawn == false)
        {
            gameController.GetComponent<GameController>().gameEnded = true;
        }
    }
/*
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
    }*/
}
