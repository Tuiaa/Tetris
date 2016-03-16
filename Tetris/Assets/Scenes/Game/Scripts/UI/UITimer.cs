using UnityEngine;
using UnityEngine.UI;

/*
 *  Shows time since starting the game
 */
public class UITimer : MonoBehaviour
{
    public Text timerLabel;
    public bool stopTimer = false;

    float time;

    void Update()
    {
        if (stopTimer == false)
        {
            time += Time.deltaTime;

            float minutes = time / 60;
            float seconds = time % 60;

            timerLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }
}