using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject Spawner;

    void Start ()
    {
        Spawner.GetComponent<BlockSpawner>().spawnBlock();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
