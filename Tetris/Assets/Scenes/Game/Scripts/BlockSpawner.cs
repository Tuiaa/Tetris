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
    public static int[,] blockPositions;

    bool firstBlock = false;
    int current;
    int next;

    float spawnPosY;

    void Start()
    {
        blockPositions = new int[(int)Grid.GetComponent<Grid>().gridWidth, (int)Grid.GetComponent<Grid>().gridHeight];
    }

    public void spawnBlock()
    {
        spawnPosY = (Grid.GetComponent<Grid>().gridHeight / 2);

        if (firstBlock == false)
        {
            current = Random.Range(0, 6);
            block = Instantiate(blocks[current], new Vector3(0.5F, spawnPosY, -0.5F), Quaternion.identity) as GameObject;
            block.transform.parent = transform;
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

    void initializeArray()
    {
        float height = (int)Grid.GetComponent<Grid>().gridHeight;
        float width = (int)Grid.GetComponent<Grid>().gridWidth;

        for (float i = height; i < width; i--)
        {
            for (float j = width; j < height; j--)
            {
                blockPositions[(int)i, (int)j] = 0;
            }
        }

    }
}
