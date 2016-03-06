using UnityEngine;
using System.Collections;

/*
 *  Border scaling and positions
 */
public class Borders : MonoBehaviour {

    public GameObject Grid;

    public GameObject BorderLeft;
    public GameObject BorderRight;
    public GameObject BorderUp;
    public GameObject BorderDown;

    public float positionX;
    public float positionY;
    float scaleX;
    float scaleY;

    public void borderPosition()
    {
        positionX = (Grid.GetComponent<Grid>().gridWidth / 2) + 0.5F;
        positionY = (Grid.GetComponent<Grid>().gridHeight / 2) + 0.5F;

        scaleX = Grid.GetComponent<Grid>().gridScaleX;
        scaleY = Grid.GetComponent<Grid>().gridScaleY;

        BorderLeft.transform.localScale += new Vector3(0.1F, 0, scaleY + 0.2F);
        BorderLeft.transform.position = new Vector3(-positionX, 0, 0);

        BorderRight.transform.localScale += new Vector3(0.1F, 0, scaleY + 0.2F);
        BorderRight.transform.position = new Vector3(+positionX, 0, 0);

        BorderUp.transform.localScale += new Vector3(scaleX, 0, 0.1F);
        BorderUp.transform.position = new Vector3(0, positionY, 0);

        BorderDown.transform.localScale += new Vector3(scaleX, 0, 0.1F);
        BorderDown.transform.position = new Vector3(0, -positionY, 0);
    }
}
