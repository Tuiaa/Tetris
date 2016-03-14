using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int score;

    public void setScore(int score)
    {
        this.score += score;
    }
}
