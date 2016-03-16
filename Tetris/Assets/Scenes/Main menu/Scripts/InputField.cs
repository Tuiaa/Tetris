using UnityEngine;
using UnityEngine.UI;

/*
 *  Input fields for grid width and height
 */
public class InputField : MonoBehaviour {

    public GameObject globalObject;

    public void setWidth(string userInput)
    {
        globalObject.GetComponent<GlobalControl>().width = userInput;
    }

    public void setHeight(string userInput)
    {
        globalObject.GetComponent<GlobalControl>().height = userInput;
    }
}
