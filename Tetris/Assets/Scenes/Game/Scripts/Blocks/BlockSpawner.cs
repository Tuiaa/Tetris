using UnityEngine;

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
        int current = Random.Range(0, blocks.Length);
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
        bool canSpawn = grid.GetComponent<Grid>().checkCurrentPosInArray();
        if (canSpawn == false)
        {
            gameController.GetComponent<GameController>().gameEnded = true;
        }
    }
}
