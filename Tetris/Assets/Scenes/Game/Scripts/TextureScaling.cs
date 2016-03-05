using UnityEngine;
using System.Collections;

public class TextureScaling : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        this.gameObject.GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", new Vector2(this.gameObject.transform.lossyScale.x, this.gameObject.transform.lossyScale.y));
    }
}