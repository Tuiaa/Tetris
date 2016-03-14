using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    public void startGame()
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
