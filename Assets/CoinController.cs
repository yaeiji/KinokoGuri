using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	private GameObject player;
	private GameObject IgaGenerator;

	private int g;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Main Camera");
		IgaGenerator = GameObject.Find ("IgaguriGenarator");
		this.transform.Rotate (0, Random.Range(0,360), 0);

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, 3, 0);
		//g = Random.Range (0, 2);
		//Debug.Log (g);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "MainCamera") {
			g=Random.Range (0, 2);
			if (g == 0) {
				player.GetComponent<PlayerController> ().Tokushu1 = true;
			} else if (g == 1) {
				IgaGenerator.GetComponent<IgaguriGenerator> ().Tokushu2Time = 0f;
				IgaGenerator.GetComponent<IgaguriGenerator> ().Tokushu2 = true;
			}
			Destroy (this.gameObject);
		}
	}
}
