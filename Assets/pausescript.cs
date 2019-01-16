using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausescript : MonoBehaviour {

	public GameObject PauseUIPrefab;
	private GameObject pauseUIInstance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (pauseUIInstance == null) {
				pauseUIInstance = GameObject.Instantiate (PauseUIPrefab) as GameObject;
				Time.timeScale = 0f;
			} else {
				Destroy (pauseUIInstance);
				Time.timeScale = 1f;
			}
		}
	}
}
