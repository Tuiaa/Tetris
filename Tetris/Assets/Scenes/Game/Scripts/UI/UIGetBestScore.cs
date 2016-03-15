using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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