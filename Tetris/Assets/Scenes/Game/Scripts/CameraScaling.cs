using UnityEngine;
using System.Collections;

/*
 *  Camera scaling changes when grid size is modified
 */
public class CameraScaling : MonoBehaviour {

    public Transform grid;
    public Camera mainCam;

    public float scale;
    public float height;
    float scaleMultiplier = 0.6F;

    float minHeight = 7.0F;

    public void scaleCamera()
    {
        height = grid.GetComponent<Grid>().gridHeight;
        scale = (height * scaleMultiplier) + 1;

        if (scale < minHeight)
        {
            mainCam.orthographicSize = minHeight;
        } else
        {
            mainCam.orthographicSize = scale;
        }
    }
}
