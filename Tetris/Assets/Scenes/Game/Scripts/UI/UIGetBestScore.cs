using UnityEngine;
using UnityEngine.UI;

/*
 *  Shows the best score
 */
public class UIGetBestScore : MonoBehaviour
{
    public GameObject gameController;
    public static int bestScore;
    Text bestScoreText;

    void Awake()
    {
        bestScoreText = GetComponent<Text>();
        bestScore = gameController.GetComponent<ScoreManager>().bestScore;
        bestScoreText.text = "Best score: " + bestScore;
    }
}