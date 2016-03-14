using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void startGame ()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void exitGame()
    {

    }
}
