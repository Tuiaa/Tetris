using UnityEngine;
using System.Collections;

/*
 *  Camera scaling changes when grid size is modified
 */
public class CameraScaling : MonoBehaviour {

    public Transform grid;

    public float scale;

    public float scaleMultiplier = 0.6F;
    public float minHeight = 7.0F;

    public void scaleCamera()
    {
        float width = grid.GetComponent<Grid>().gridWidth;
        float height = grid.GetComponent<Grid>().gridHeight;

        if (width >= height)
        {
            scale = (width * scaleMultiplier) + 1;
        }
        else
        {
            scale = (height * scaleMultiplier) + 1;
        }

        Camera.main.transform.position = new Vector3(width / 2.0f, height / 2.0f, -70);
        Camera.main.orthographicSize = scale;
        /*
        if (scale < minHeight)
        {
            Camera.main.orthographicSize = minHeight;
        } else
        {
            
        }*/


    }
}
