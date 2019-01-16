using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCon : MonoBehaviour {

    GameObject player;
	GameObject hpcomp;
	private int hp;
	Slider hpslider;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Main Camera");


		hpslider=GameObject.Find("Slider").GetComponent<Slider>();
		hp = 100;
		hpslider.value = hp;
	}
	
	// Update is called once per frame
	void Update () {
		hp = player.GetComponent<PlayerController> ().HP;
		//Debug.Log (hp);
		hpslider.value = hp;
	}
}
