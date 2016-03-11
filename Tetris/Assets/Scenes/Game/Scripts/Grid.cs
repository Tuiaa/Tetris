using UnityEngine;
using System.Collections;

/*
 *  Grid creation and scaling, keeps track of block positions
 */
public class Grid : MonoBehaviour
{
    public Renderer GridRend;
    public GameObject Borders;
    public Camera mainCamera;
    public GameObject[,] blockPositions;
    public GameObject blockSpawn;
    public GameObject stuckBlock;
    public GameObject gameController;

    public GameObject currentBlock;

    public enum Directions { LEFT, RIGHT, DOWN, UP };

    public int gridWidth = 10;
    public int gridHeight = 20;

    public float gridScaleX;
    public float gridScaleY;

    public void Start()
    {
        GridRend = GetComponent<Renderer>();

        changeGridScale();
        changeMaterialTiling();

        Borders.GetComponent<Borders>().borderPosition();
        mainCamera.GetComponent<CameraScaling>().scaleCamera();
        blockPositions = new GameObject[gridWidth, gridHeight];
        initializeArray();
    }

    void changeGridScale()
    {
        gridScaleX = (float)gridWidth / 10.0F;
        gridScaleY = (float)gridHeight / 10.0F;
        transform.localScale += new Vector3(gridScaleX, 0, gridScaleY);
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

    public bool checkArray(Directions dir)
    {
        int blockBoxPosX;
        int blockBoxPosY;

        for (int i = 0; i < currentBlock.transform.childCount; i++)
        {
            GameObject child = currentBlock.transform.GetChild(i).gameObject;

            blockBoxPosX = child.GetComponent<BoxPosition>().arrayPosX;
            blockBoxPosY = child.GetComponent<BoxPosition>().arrayPosY;

            if(dir == Directions.LEFT)
            {
                blockBoxPosX -= 1;
            }
            else if (dir == Directions.RIGHT)
            {
                blockBoxPosX += 1;
            }
            else if (dir == Directions.DOWN)
            {
                blockBoxPosY -= 1;
            }
            else if (dir == Directions.UP)
            {
                blockBoxPosX -= gameController.GetComponent<GameController>().rotatePosX;
                blockBoxPosY -= gameController.GetComponent<GameController>().rotatePosY;
            }

            if (blockBoxPosY + 1 == 0)
            {
                return false;
            }
            else if (blockBoxPosX == gridWidth || blockBoxPosX + 1 == 0)
            {
                return false;
            }
            else if (blockPositions[blockBoxPosX, blockBoxPosY] != null)
            {
                return false;
            }
        }
        return true;
    }

    public void moveToStuckBlocks()
    {
        for (int i = currentBlock.transform.childCount -1; i >= 0; i--)
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
}
