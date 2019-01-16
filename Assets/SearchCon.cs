using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCon : MonoBehaviour {
	private int a=0;

	public GameObject KingMush;
	public GameObject KingRange;

	// Use this for initialization
	void Start () {
		KingMush = GameObject.Find ("KingMush");
		KingRange = GameObject.Find ("KingRange");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		//Debug.Log ("あ");
		if (col.tag == "MainCamera") {
			if (a == 0) {
				col.GetComponent<PlayerController> ().BGMkirikae2 = false;
				KingMush.GetComponent<KingMushController>().target1 = col.gameObject;
			}
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "MainCamera") {
			if (a == 0) {
				col.GetComponent<PlayerController> ().BGMkirikae2 = true;
				KingMush.GetComponent<KingMushController>().target1 = KingRange;
			}
		}
	}
}
