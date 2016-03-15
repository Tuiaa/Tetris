using UnityEngine;
using System.Collections;

/*
 *  Keeps track of current score
 */
public class ScoreManager : MonoBehaviour {

    public int score;
    public int bestScore;

    public void setScore(int score)
    {
        this.score += score;
    }
}
