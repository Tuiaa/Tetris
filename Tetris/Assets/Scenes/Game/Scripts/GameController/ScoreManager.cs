using UnityEngine;

/*
 *  Keeps track of scores
 */
public class ScoreManager : MonoBehaviour
{

    public int score;
    public int bestScore;

    public void setScore(int score)
    {
        this.score += score;
    }
}
