using UnityEngine;
using System.Collections;

/*
 *  Camera scaling changes when grid size is modified
 */
public class CameraScaling : MonoBehaviour {

    public Transform Grid;
    public Camera MainCam;

    public float scale;
    public float height;
    float scaleMultiplier = 0.6F;

    float minHeight = 7.0F;

    public void scaleCamera()
    {
        height = Grid.GetComponent<Grid>().gridHeight;
        scale = (height * scaleMultiplier) + 1;

        if (scale < minHeight)
        {
            MainCam.orthographicSize = minHeight;
        } else
        {
            MainCam.orthographicSize = scale;
        }
    }
}
