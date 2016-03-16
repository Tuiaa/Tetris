using UnityEngine;
using UnityEngine.UI;

/*
 *  Keeps track of scores
 */
public class ScoreManager : MonoBehaviour
{
    public int score;
    public int bestScore;

    public GameObject currentScoreObject;
    public GameObject bestScoreObject;

    private Text bestScoreText;
    private Text currentScoreText;

    void Start()
    {
        bestScoreText = bestScoreObject.GetComponent<Text>();
        bestScoreText.text = "Best score: " + bestScore;

        currentScoreText = currentScoreObject.GetComponent<Text>();
        score = 0;
        currentScoreText.text = "Current score: " + score;
    }

    public void addToScore(int addScore)
    {
        score += addScore;
        currentScoreText.text = "Current score: " + score;
    }

    public bool isNewHighScore()
    {
        if (bestScore < score)
        {
            return true;
        }
        else {
            return false;
        }
    }
}
