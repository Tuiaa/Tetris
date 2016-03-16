using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  Button for restarting the game
 */
public class UIButtons : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}