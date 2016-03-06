using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            //transform.parent.GetComponent<BlockSpawner>().

            // See if valid
            //if (isValidGridPos())
            // Its valid. Update grid.
            //updateGrid();
            //else
            // Its not valid. revert.
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
}
