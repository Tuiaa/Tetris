using UnityEngine;
using System.Collections;

/*
 *  Spawns blocks and keeps track of their positions
 */
public class BlockSpawner : MonoBehaviour
{
    public GameObject Grid;
    public GameObject[] blocks;
    public GameObject block;
    

    bool firstBlock = false;
    int current;
    int next;

    float spawnPosY;

    float height;
    float width;

    void Start()
    {
       
        
    }

    public void spawnBlock()
    {
        spawnPosY = (Grid.GetComponent<Grid>().gridHeight / 2);

        if (firstBlock == false)
        {
            current = Random.Range(0, 6);
            //block = Instantiate(blocks[current], new Vector3(0.5F, spawnPosY, -0.5F), Quaternion.identity) as GameObject;
            block = Instantiate(blocks[0], new Vector3(0.5F, spawnPosY, -0.5F), Quaternion.identity) as GameObject;
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
