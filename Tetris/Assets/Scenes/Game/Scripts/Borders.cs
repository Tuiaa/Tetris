using UnityEngine;
using System.Collections;

/*
 *  Border scaling and positions
 */
public class Borders : MonoBehaviour {

    public GameObject grid;

    public GameObject borderLeft;
    public GameObject borderRight;
    public GameObject borderUp;
    public GameObject borderDown;

    public float positionX;
    public float positionY;
    float scaleX;
    float scaleY;

    public void borderPosition()
    {
        if (grid.GetComponent<Grid>().gridWidth % 2 == 0)
        {
            positionX = (grid.GetComponent<Grid>().gridWidth / 2) + 0.5F;
        }
        else
        {
            positionX = (grid.GetComponent<Grid>().gridWidth / 2) + (grid.GetComponent<Grid>().gridWidth % 2);
        }
        if (grid.GetComponent<Grid>().gridHeight % 2 == 0)
        {
            positionY = (grid.GetComponent<Grid>().gridHeight / 2) + 0.5F;
        }
        else
        {
            positionY = (grid.GetComponent<Grid>().gridHeight / 2) + (grid.GetComponent<Grid>().gridHeight % 2);
        }

        scaleX = grid.GetComponent<Grid>().gridScaleX;
        scaleY = grid.GetComponent<Grid>().gridScaleY;

        borderLeft.transform.localScale += new Vector3(0.1F, 0, scaleY + 0.2F);
        borderLeft.transform.position = new Vector3(-positionX, 0, 0);

        borderRight.transform.localScale += new Vector3(0.1F, 0, scaleY + 0.2F);
        borderRight.transform.position = new Vector3(+positionX, 0, 0);

        borderUp.transform.localScale += new Vector3(scaleX, 0, 0.1F);
        borderUp.transform.position = new Vector3(0, positionY, 0);

        borderDown.transform.localScale += new Vector3(scaleX, 0, 0.1F);
        borderDown.transform.position = new Vector3(0, -positionY, 0);
    }
}
