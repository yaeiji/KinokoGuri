using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenarator : MonoBehaviour {

	public GameObject applePrefab;
	public GameObject ItemIgaguriPrefab;
	public GameObject player;

	private float appearTime=5.0f;
	private float appeTime=5.0f;
	private int MaxItem = 100;
	public int numItem=0;
	public bool hantei;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		appearTime += Time.deltaTime;

		if (appearTime >= appeTime && MaxItem>=numItem&&hantei) {
			int num = Random.Range (1, 4);
			numItem += num;
			for (int i = 0; i < num; i++) {
				
				int basho = Random.Range (1, 5);
				if (basho == 1) {
					int shu = Random.Range (0, 5);
					if (shu == 3) {
						GameObject apple = Instantiate (applePrefab) as GameObject;
						apple.transform.position = new Vector3 (player.transform.position.x + Random.Range (0, 5), 0, player.transform.position.z + 25 + Random.Range (0, 5));
					} else {
						GameObject ItemIga = Instantiate (ItemIgaguriPrefab) as GameObject;
						ItemIga.transform.position = new Vector3 (player.transform.position.x + Random.Range (0, 5), 0.3f, player.transform.position.z + 25 + Random.Range (0, 5));
					}
				} else if (basho == 2) {
					int shu = Random.Range (0, 5);
					if (shu == 3) {
						GameObject apple = Instantiate (applePrefab) as GameObject;
						apple.transform.position = new Vector3 (player.transform.position.x + Random.Range (0, 5), 0, player.transform.position.z - 25 + Random.Range (0, 5));
					} else {
						GameObject ItemIga = Instantiate (ItemIgaguriPrefab) as GameObject;
						ItemIga.transform.position = new Vector3 (player.transform.position.x + Random.Range (0, 5), 0.3f, player.transform.position.z - 25 + Random.Range (0, 5));
					}
				} else if (basho == 3) {
					int shu = Random.Range (0, 5);
					if (shu == 3) {
						GameObject apple = Instantiate (applePrefab) as GameObject;
						apple.transform.position = new Vector3 (player.transform.position.x + 25 + Random.Range (0, 5), 0, player.transform.position.z + Random.Range (0, 5));
					} else {
						GameObject ItemIga = Instantiate (ItemIgaguriPrefab) as GameObject;
						ItemIga.transform.position = new Vector3 (player.transform.position.x + 25 + Random.Range (0, 5), 0.3f, player.transform.position.z + Random.Range (0, 5));
					}
				} else if (basho == 4) {
					int shu = Random.Range (0, 5);
					if (shu == 3) {
						GameObject apple = Instantiate (applePrefab) as GameObject;
						apple.transform.position = new Vector3 (player.transform.position.x - 25 + Random.Range (0, 5), 0, player.transform.position.z + Random.Range (0, 5));
					} else {
						GameObject ItemIga = Instantiate (ItemIgaguriPrefab) as GameObject;
						ItemIga.transform.position = new Vector3 (player.transform.position.x - 25 + Random.Range (0, 5), 0.3f, player.transform.position.z + Random.Range (0, 5));
					}
				}


			}
			appearTime = 0f;
		}
	}
}
