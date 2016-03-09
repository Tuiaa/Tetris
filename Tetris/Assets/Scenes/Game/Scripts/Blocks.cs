using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour
{
    public GameObject grid;
    public GameObject blockSpawner;

    public int blockBoxPosX;
    public int blockBoxPosY;

    public float nextMove = 0.0F;
    public float movingSpeed = 1.0F;

    void Start()
    {
        nextMove = Time.time + 1.0F;
        grid = GameObject.Find("Grid");
        blockSpawner = GameObject.Find("BlockSpawner");
    }

    void Update()
    {
        if (Time.time > nextMove)
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.DOWN);
            if(canMove)
            {
                transform.position += new Vector3(0, -1, 0);
                nextMove = Time.time + movingSpeed;
                updateBoxPositions(0, -1);
            } else
            {
                grid.GetComponent<Grid>().moveToStuckBlocks();
                blockSpawner.GetComponent<BlockSpawner>().spawnBlock();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.LEFT);
            if (canMove == true)
            {
                transform.position += new Vector3(-1, 0, 0);
                updateBoxPositions(-1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.RIGHT);
            if (canMove)
            {
                transform.position += new Vector3(1, 0, 0);
                updateBoxPositions(1, 0);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.DOWN);
            if (canMove)
            {
                transform.position += new Vector3(0, -1, 0);
                updateBoxPositions(0, -1);
            }
        }
    }

    void updateBoxPositions(int posX, int posY)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<BoxPosition>().arrayPosX += posX;
            child.GetComponent<BoxPosition>().arrayPosY += posY;
        }
    }
}
