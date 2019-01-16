using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenarator : MonoBehaviour {

	public GameObject CoinPrefab;
	private GameObject Coinchan;

	private GameObject player;

	private float coinTime=30f; 
	private float coinChanTime = 0f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		coinTime += Time.deltaTime;
		coinChanTime += Time.deltaTime;

		if (coinTime >= 60.0f) {
			Coinchan = Instantiate (CoinPrefab) as GameObject;
			Coinchan.transform.position = new Vector3 (player.transform.position.x + Random.Range (-20, 20), 0, transform.position.z + Random.Range (-20, 20));
			coinChanTime = 0f;
			coinTime = 0f;
		}

		if (coinChanTime>=30f) {
			Destroy (Coinchan.gameObject);
		}
	}
}
