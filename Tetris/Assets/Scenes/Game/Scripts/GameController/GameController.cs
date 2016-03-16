using UnityEngine;

/*
 *  Moves blocks, updates their positions, ends game
 */
public class GameController : MonoBehaviour
{

    public GameObject spawner;
    public GameObject grid;
    public GameObject block;
    public GameObject gameOver;

    public int rotatedPosX;
    public int rotatedPosY;

    public float nextMove = 0.0F;
    public int movingSpeed = 1;
    public bool gameEnded = false;
    public bool gameSaved = false;

    void Awake()
    {
        nextMove = Time.time + 1.0F;
    }

    void Start()
    {
        grid = GameObject.Find("Grid");
        spawner = GameObject.Find("BlockSpawner");

        spawner.GetComponent<BlockSpawner>().spawnBlock();
    }

    void Update()
    {
        if (gameEnded == true)
        {
            gameOver.SetActive(true);
            if (gameSaved == false)
            {
                gameObject.GetComponent<DataSaver>().Save();
                GameObject.Find("Canvas").GetComponentInChildren<UITimer>().stopTimer = true;
                gameSaved = true;
            }
        }
        else
        {
            block = GameObject.Find("CurrentBlock");

            if (Time.time > nextMove)
            {
                /* Check if block can move and then move it down every second */
                bool canMove = grid.GetComponent<Grid>().checkArrayToDirection(Grid.Directions.DOWN);
                if (canMove)
                {
                    block.GetComponent<CurrentBlock>().moveBlock(Grid.Directions.DOWN, movingSpeed);
                    nextMove = Time.time + movingSpeed;
                }
                else
                {
                    /* If block can't be moved it is inserted into stucked blocks */
                    grid.GetComponent<Grid>().moveToStuckBlocks();
                    grid.GetComponent<Grid>().removeRow();
                    spawner.GetComponent<BlockSpawner>().spawnBlock();
                }
            }
            /* LEFT direction */
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                bool canMove = grid.GetComponent<Grid>().checkArrayToDirection(Grid.Directions.LEFT);
                if (canMove == true)
                {
                    block.GetComponent<CurrentBlock>().moveBlock(Grid.Directions.LEFT, movingSpeed);
                }
            }
            /* RIGHT direction */
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                bool canMove = grid.GetComponent<Grid>().checkArrayToDirection(Grid.Directions.RIGHT);
                if (canMove)
                {
                    block.GetComponent<CurrentBlock>().moveBlock(Grid.Directions.RIGHT, movingSpeed);
                }
            }
            /* DOWN direction */
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                bool canMove = grid.GetComponent<Grid>().checkArrayToDirection(Grid.Directions.DOWN);
                while (canMove)
                {
                    block.GetComponent<CurrentBlock>().moveBlock(Grid.Directions.DOWN, movingSpeed);
                    canMove = grid.GetComponent<Grid>().checkArrayToDirection(Grid.Directions.DOWN);
                }

                grid.GetComponent<Grid>().moveToStuckBlocks();
                grid.GetComponent<Grid>().removeRow();
                spawner.GetComponent<BlockSpawner>().spawnBlock();
            }
            /* UP direction */
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rotateBlock();
            }
        }
    }

    public void rotateBlock()
    {
        if (block.GetComponent<CurrentBlock>().canBlockRotate == true)
        {
            for (int i = 0; i < block.transform.childCount; i++)
            {
                GameObject child = block.transform.GetChild(i).gameObject;

                int offSetX = child.GetComponent<BoxPosition>().offSetX;
                int offSetY = child.GetComponent<BoxPosition>().offSetY;

                /* Rotation matrix -90 degrees*/
                rotatedPosX = (0 * offSetX) + (1 * offSetY);
                rotatedPosY = (-1 * offSetX) + (0 * offSetY);

                child.GetComponent<BoxPosition>().setOffset(rotatedPosX, rotatedPosY);
                block.GetComponent<CurrentBlock>().updateChildArrayPos();
            }

            bool canRotate = grid.GetComponent<Grid>().checkCurrentPosInArray();

            if (canRotate)
            {
                /* If can rotate, sets new offsets and Unity positions */
                for (int i = 0; i < block.transform.childCount; i++)
                {
                    GameObject child = block.transform.GetChild(i).gameObject;

                    int arrayPosX = child.GetComponent<BoxPosition>().arrayPosX;
                    int arrayPosY = child.GetComponent<BoxPosition>().arrayPosY;

                    grid.GetComponent<Grid>().setUnityPosition(child, arrayPosX, arrayPosY);
                }
            }
            else
            {
                /* If can't rotate, reverses positions */
                for (int i = 0; i < block.transform.childCount; i++)
                {
                    GameObject child = block.transform.GetChild(i).gameObject;
                    int offSetX = child.GetComponent<BoxPosition>().offSetX;
                    int offSetY = child.GetComponent<BoxPosition>().offSetY;

                    /* Rotation matrix 90 degrees */
                    rotatedPosX = (0 * offSetX) + (-1 * offSetY);
                    rotatedPosY = (1 * offSetX) + (0 * offSetY);

                    child.GetComponent<BoxPosition>().setOffset(rotatedPosX, rotatedPosY);

                    block.GetComponent<CurrentBlock>().updateChildArrayPos();
                }
            }
        }
    }
}
