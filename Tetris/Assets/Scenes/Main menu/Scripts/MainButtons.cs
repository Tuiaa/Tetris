using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 *  Button for starting the game
 */
public class MainButtons : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
