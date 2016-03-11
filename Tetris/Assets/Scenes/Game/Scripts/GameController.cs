using UnityEngine;
using System.Collections;

/*
 *  Moves blocks, updates their positions, ends game
 */
public class GameController : MonoBehaviour {

    public GameObject spawner;
    public GameObject grid;
    public GameObject block;

    public int blockBoxPosX;
    public int blockBoxPosY;

    public float nextMove = 0.0F;
    public float movingSpeed = 1.0F;

    void Start ()
    {
        spawner = GameObject.Find("BlockSpawner");
        grid = GameObject.Find("Grid");

        nextMove = Time.time + 1.0F;
        spawner.GetComponent<BlockSpawner>().spawnBlock();      
    }

	void Update () {
        block = GameObject.Find("CurrentBlock");

        if (Time.time > nextMove)
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.DOWN);
            if (canMove)
            {
                block.transform.position += new Vector3(0, -1, 0);
                nextMove = Time.time + movingSpeed;
                block.GetComponent<Blocks>().updateBoxPositions(0, -1);
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
                block.transform.position += new Vector3(-1, 0, 0);
                block.GetComponent<Blocks>().updateBoxPositions(-1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.RIGHT);
            if (canMove)
            {
                block.transform.position += new Vector3(1, 0, 0);
                block.GetComponent<Blocks>().updateBoxPositions(1, 0);
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.DOWN);
            if (canMove)
            {
                block.transform.position += new Vector3(0, -1, 0);
               block.GetComponent<Blocks>().updateBoxPositions(0, -1);
            }
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
}
