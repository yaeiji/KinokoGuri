using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject MushPrefab;
	private float apperNextTime=10.0f;
	public int numberOfEnemys;
	private float elapsedTime;

	// Use this for initialization
	void Start () {
		numberOfEnemys = 0;
		elapsedTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		elapsedTime += Time.deltaTime;

		if (elapsedTime > apperNextTime) {
			elapsedTime = 0f;

			AppearEnemy ();
		}
	}

	void AppearEnemy(){
		GameObject Mush = Instantiate (MushPrefab) as GameObject;
		Mush.transform.position = new Vector3(transform.position.x+Random.Range(-10,10),transform.position.y,transform.position.z+Random.Range(-10,10));
	}
}
