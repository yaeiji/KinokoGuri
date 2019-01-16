using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIgaguri : MonoBehaviour {
	public GameObject player;
	public GameObject numI;
	private AudioClip get;
	private float aptime;
	private float aatime=100f;

	public GameObject IgaguriGene;
	// Use this for initialization
	void Start () {
		IgaguriGene = GameObject.Find ("IgaguriGenarator");
		numI = GameObject.Find ("ItemGenerator");
		aptime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (aptime >= aatime) {
			numI.GetComponent<ItemGenarator> ().numItem--;
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "MainCamera") {
			
			this.GetComponent<AudioSource> ().Play ();
			IgaguriGene.GetComponent<IgaguriGenerator> ().NumIgaguri++;
			numI.GetComponent<ItemGenarator> ().numItem--;
			Destroy (this.gameObject);
		}
	}
}
