using UnityEngine;
using UnityEngine.UI;

/*
 *  Makes blocks move faster when levels go higher
 */
public class LevelDifficulty : MonoBehaviour {

    public GameObject currentLevelObject;
    private Text currentLevelText;


    int levelNumber = 1;
    int rowsToLevelUp = 5;

    void Start ()
    {
        currentLevelText = currentLevelObject.GetComponent<Text>();
        currentLevelText.text = "Level: " + levelNumber;
    }

    public void decreaseRows (int amount)
    {
        rowsToLevelUp -= amount;
        if(rowsToLevelUp <= 0)
        {
            addLevel(1);
        }
    }

    public void addLevel(int add)
    {
        levelNumber += add;
        currentLevelText.text = "Level: " + levelNumber;
    }

}
