using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject spawner;

    void Start ()
    {
        spawner.GetComponent<BlockSpawner>().spawnBlock();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
