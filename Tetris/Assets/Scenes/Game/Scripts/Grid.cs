using UnityEngine;
using System.Collections;

/*
 *  Grid creation and scaling
 */
public class Grid : MonoBehaviour
{
    public Renderer GridRend;

    public float gridWidth = 10;
    public float gridHeight = 20;

    public void Start()
    {
        GridRend = GetComponent<Renderer>();
        changeGridScale();
        changeMaterialTiling();
    }

    void Update()
    {

    }

    void changeGridScale()
    {
        float gridScaleX = gridWidth / 10.0F;
        float gridScaleY = gridHeight / 10.0F;
        transform.localScale += new Vector3(gridScaleX, 0, gridScaleY);
    }

    void changeMaterialTiling()
    {
        GridRend.material.mainTextureScale = new Vector2(gridWidth, gridHeight);
    }
}
