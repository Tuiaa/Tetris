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
    public int rotatePosX;
    public int rotatePosY;

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
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bool canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.UP);
            if (canMove)
            {
                rotateArrayPos();
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

    public void rotateArrayPos()
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            GameObject child = block.transform.GetChild(i).gameObject;
            int childLocalPosX = (int)child.transform.localPosition.x;
            int childLocalPosY = (int)child.transform.localPosition.y;

            int childArrayPosX = (int)child.GetComponent<BoxPosition>().offSetX;
            int childArrayPosY = (int)child.GetComponent<BoxPosition>().offSetY;
            //Debug.Log("childposX = " + childPosX + " childposY = " + childPosY);

            // Rotation matrix, X: cos(-PI/2) * x + -sin(-PI/2), Y: sin(-PI/2) + cos(-PI/2)

            rotatePosX = (0 * childLocalPosX) + (1 * childLocalPosY);
            rotatePosY = (-1 * childLocalPosX) + (0 * childLocalPosY);

            rotatePosX = (0 * childArrayPosX) + (1 * childArrayPosY);
            rotatePosY = (-1 * childArrayPosX) + (0 * childArrayPosY);

            Debug.Log("posX = " + rotatePosX + " posY = " + rotatePosY);
            childLocalPosX = rotatePosX;
            childLocalPosY = rotatePosY;
            child.transform.localPosition = new Vector3(rotatePosX, rotatePosY, 0);
            updateBoxPositions(rotatePosX, rotatePosY);
        }
    }
}
