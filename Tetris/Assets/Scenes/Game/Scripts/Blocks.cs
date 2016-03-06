using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour
{
    public GameObject grid;

    public int blockBoxPosX;
    public int blockBoxPosY;

    public float nextMove = 0.0F;
    public float movingSpeed = 1.0F;
    bool canMove = true;

    void Start()
    {
        nextMove = Time.time + 1.0F;
        grid = GameObject.Find("Grid");
    }

    void Update()
    {
        if (Time.time > nextMove)
        {
            
                transform.position += new Vector3(0, -1, 0);
                nextMove = Time.time + movingSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            canMove = grid.GetComponent<Grid>().checkArray(Grid.Directions.LEFT);
            if (canMove == true)
            {
                transform.position += new Vector3(-1, 0, 0);
                
            } else
            {
                Debug.Log("Not possible to move");
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
        }
    }

    void updateBoxPositions()
    {

    }
}
