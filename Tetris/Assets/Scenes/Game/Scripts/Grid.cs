using UnityEngine;

/*
 *  Grid creation and scaling, keeps track of block positions
 */
public class Grid : MonoBehaviour
{
    public GameObject blockSpawn;
    public GameObject stuckBlock;
    public GameObject gameController;
    [HideInInspector]
    public GameObject currentBlock;

    private GameObject globalObject;
    private GameObject[,] blockPositions;
    private Renderer GridRend;

    public enum Directions { LEFT, RIGHT, DOWN, UP };

    public int gridWidth = 10;
    public int gridHeight = 20;

    public void Start()
    {
        globalObject = GameObject.Find("GlobalObject");
        GridRend = GetComponent<Renderer>();

        getGridDimensions();
        changeGridScale();
        changeMaterialTiling();
        Camera.main.GetComponent<CameraScaling>().scaleCamera();

        blockPositions = new GameObject[gridWidth, gridHeight];
        initializeArray();
    }

    void getGridDimensions()
    {
        gridWidth = int.Parse(globalObject.GetComponent<GlobalControl>().width);
        gridHeight = int.Parse(globalObject.GetComponent<GlobalControl>().height);
    }

    void changeGridScale()
    {
        float gridScaleX = (float)gridWidth / 10.0F;
        float gridScaleY = (float)gridHeight / 10.0F;

        transform.localScale += new Vector3(gridScaleX, 0, gridScaleY);
        transform.position = new Vector3(gridWidth / 2.0f, gridHeight / 2.0f, 1);
    }

    void changeMaterialTiling()
    {
        GridRend.material.mainTextureScale = new Vector2(gridWidth, gridHeight);
    }

    void initializeArray()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                blockPositions[i, j] = null;
            }
        }
    }

    /* Returns false if block can't move */
    public bool checkCurrentPosInArray()
    {
        for (int i = 0; i < currentBlock.transform.childCount; i++)
        {
            GameObject child = currentBlock.transform.GetChild(i).gameObject;

            int arrayPosX = child.GetComponent<BoxPosition>().arrayPosX;
            int arrayPosY = child.GetComponent<BoxPosition>().arrayPosY;
            if (arrayPosX < 0)
            {
                return false;
            }
            else if (arrayPosY < 0)
            {
                return false;
            }
            else if (arrayPosX > gridWidth - 1)
            {
                return false;
            }
            else if (arrayPosY > gridHeight - 1)
            {
                return false;
            }

            if (blockPositions[arrayPosX, arrayPosY] != null)
            {
                return false;
            }
        }
        return true;
    }

    /* Returns false if block can't move to given direction */
    public bool checkArrayToDirection(Directions dir)
    {
        int childArrayPosX;
        int childArrayPosY;

        for (int i = 0; i < currentBlock.transform.childCount; i++)
        {
            GameObject child = currentBlock.transform.GetChild(i).gameObject;

            childArrayPosX = child.GetComponent<BoxPosition>().arrayPosX;
            childArrayPosY = child.GetComponent<BoxPosition>().arrayPosY;

            if (blockPositions[childArrayPosX, childArrayPosY] != null)
            {
                return false;
            }

            if (dir == Directions.LEFT)
            {
                childArrayPosX -= 1;
            }
            else if (dir == Directions.RIGHT)
            {
                childArrayPosX += 1;
            }
            else if (dir == Directions.DOWN)
            {
                childArrayPosY -= 1;
            }

            if (childArrayPosY + 1 == 0)
            {
                return false;
            }
            else if (childArrayPosX == gridWidth || childArrayPosX + 1 == 0)
            {
                return false;
            }
            else if (blockPositions[childArrayPosX, childArrayPosY] != null)
            {
                return false;
            }
        }
        return true;
    }

    public void moveToStuckBlocks()
    {
        gameController.GetComponent<ScoreManager>().addToScore(10);
        for (int i = currentBlock.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = currentBlock.transform.GetChild(i).gameObject;
            child.transform.parent = stuckBlock.transform;
            updateBlockPositionArray(child);
        }
        Destroy(currentBlock);
    }

    void updateBlockPositionArray(GameObject child)
    {
        int x = child.GetComponent<BoxPosition>().arrayPosX;
        int y = child.GetComponent<BoxPosition>().arrayPosY;
        blockPositions[x, y] = child;
    }

    public void setUnityPosition(GameObject obj, int xGridPos, int yGridPos)
    {
        obj.transform.position = new Vector3(xGridPos + 0.5f, yGridPos + 1.0f);
    }

    public void removeRow()
    {
        GameObject[,] tempArray = new GameObject[gridWidth, gridHeight];
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                tempArray[i, j] = null;
            }
        }

        bool[] rowsToRemove = checkRowsToBeRemoved();
        int width = 0;
        int height = 0;
        int howManyRows = 0;

        for (int i = 0; i < gridHeight; i++)
        {
            if (rowsToRemove[i] == false)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    tempArray[width, height] = blockPositions[j, i];
                    width++;
                }
                width = 0;
                height++;
            }
            else
            {
                howManyRows++;
                for (int j = 0; j < gridWidth; j++)
                {
                    Destroy(blockPositions[j, i]);
                }
                for (int a = i; a < gridHeight; a++)
                {
                    for (int b = 0; b < gridWidth; b++)
                    {
                        if (blockPositions[b, a] != null)
                        {
                            blockPositions[b, a].GetComponent<BoxPosition>().moveBox(Grid.Directions.DOWN, 1);
                        }
                    }
                }
            }
        }

        blockPositions = tempArray;
        int score = howManyRows * 100;
        gameController.GetComponent<ScoreManager>().addToScore(score);
    }

    bool[] checkRowsToBeRemoved()
    {
        bool[] rowsToRemove = new bool[gridHeight];
        bool isFull = true;

        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                if (blockPositions[j, i] == null)
                {
                    isFull = false;
                    break;
                }
            }
            if (isFull)
            {
                rowsToRemove[i] = true;
            }
            else
            {
                rowsToRemove[i] = false;
            }
            isFull = true;
        }
        return rowsToRemove;
    }
}
