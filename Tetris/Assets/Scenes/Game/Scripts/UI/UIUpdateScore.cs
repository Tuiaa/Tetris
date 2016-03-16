using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 *  Updates the current score
 */
public class UIUpdateScore : MonoBehaviour
{
    public GameObject gameController;
    public static int score;
    Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        score = gameController.GetComponent<ScoreManager>().score;
        scoreText.text = "Current score: " + score;
    }
}