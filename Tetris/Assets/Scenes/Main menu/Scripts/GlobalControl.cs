using UnityEngine;
using System.Collections;

/*
 *  Moves data from main menu to game
 */
public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;

    public string width = "10";
    public string height = "20";
    
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
