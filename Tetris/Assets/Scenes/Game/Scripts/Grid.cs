using UnityEngine;
using System.Collections;

/*
 *  Grid creation and scaling
 */
public class Grid : MonoBehaviour
{
    public Renderer GridRend;
    public GameObject Borders;
    public Camera MainCamera;

    public float gridWidth = 10;
    public float gridHeight = 20;

    public float gridScaleX;
    public float gridScaleY;

    public void Start()
    {
        GridRend = GetComponent<Renderer>();

        changeGridScale();
        changeMaterialTiling();

        Borders.GetComponent<Borders>().borderPosition();
        MainCamera.GetComponent<CameraScaling>().scaleCamera();
    }

    void changeGridScale()
    {
        gridScaleX = gridWidth / 10.0F;
        gridScaleY = gridHeight / 10.0F;
        transform.localScale += new Vector3(gridScaleX, 0, gridScaleY);
    }

    void changeMaterialTiling()
    {
        GridRend.material.mainTextureScale = new Vector2(gridWidth, gridHeight);
    }
}
