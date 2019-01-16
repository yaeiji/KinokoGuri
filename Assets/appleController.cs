using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleController : MonoBehaviour {

	public GameObject player;
	public int caihuku=20;
	private AudioClip get;
	public GameObject numI;
	private float aptime;
	private float aatime=100f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Main Camera");
		numI = GameObject.Find ("ItemGenerator");
		aptime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		aptime += Time.deltaTime;
		if (aptime >= aatime) {
			numI.GetComponent<ItemGenarator> ().numItem--;
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		
		if (col.gameObject.tag == "MainCamera") {
			//Debug.Log ("あ");
			this.GetComponent<AudioSource> ().Play ();
			player.GetComponent<PlayerController> ().HP += caihuku;
			if (player.GetComponent<PlayerController> ().HP >= 100) {
				player.GetComponent<PlayerController> ().HP = 100;
			}
			numI.GetComponent<ItemGenarator> ().numItem--;
			Destroy (this.gameObject);
		}
	}
}
