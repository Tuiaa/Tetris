using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}