using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgaguriGenerator : MonoBehaviour {

	public GameObject igaguriPrefab;
	public GameObject Mazzle;
	public GameObject NoIgaguriText;
	public GameObject numIgaguText;
	public GameObject TenMuguIga;
	public GameObject TenMegu;

	private float appTime=0f;
	private float apTime=2.0f;
	private bool Tokushu2hyouji=false;

	public bool Tokushu2=false;

	public int NumIgaguri=0;

	public float Tokushu2Time = 0f;


	// Use this for initialization
	void Start () {
		NoIgaguriText = GameObject.Find ("NoIgaguri");
		numIgaguText = GameObject.Find ("numIgagu");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (NumIgaguri >= 1||Tokushu2==true) {
				GameObject igaguri = Instantiate (igaguriPrefab) as GameObject;
				igaguri.transform.position = Mazzle.transform.position;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				Vector3 worldDir = ray.direction;
				igaguri.GetComponent<IgaguriController> ().Shoot (worldDir.normalized * 2000);
				NumIgaguri--;
				if (Tokushu2 == true) {
					NumIgaguri++;
				}
			} else {
				appTime = 0f;
				NoIgaguriText.GetComponent<Text>().text="I have no Igaguri";
			}
		}

		appTime += Time.deltaTime;

		if (Tokushu2 == true) {
			if (Tokushu2hyouji == false) {
				TenMegu = Instantiate (TenMuguIga) as GameObject;
				Tokushu2hyouji = true;
				Time.timeScale = 0f;
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				Destroy (TenMegu.gameObject);
				Time.timeScale = 1.0f;
			}
			Tokushu2Time += Time.deltaTime;
		}

		if (Tokushu2Time >= 60.0f) {
			Tokushu2 = false;
			Tokushu2hyouji = false;
			NumIgaguri = 0;
		}

		if (Tokushu2 == false) {
			numIgaguText.GetComponent<Text> ().text = "×" + NumIgaguri;
		} else if (Tokushu2 == true) {
			numIgaguText.GetComponent<Text>().text="×∞";
		}
		if (appTime >= apTime) {
			NoIgaguriText.GetComponent<Text>().text=" ";
		}
	}
}
