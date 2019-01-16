using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MushController : MonoBehaviour {



	public GameObject target; // 追いかける対象
	private NavMeshAgent agent;
	private Animation myani;


	public int Mushhp = 100;
	private int igaguriatk=50;
	private int a = 1;
	 
/*	public float rotMax; // 回転速度
	public float speed = 0.5f; // 移動スピード
*/
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Main Camera");
		agent=GetComponent<NavMeshAgent> ();
		myani = this.gameObject.GetComponent<Animation> ();
		agent.SetDestination (target.transform.position);
	}

	// Update is called once per frame
	void Update () {
		if (Mushhp > 0) {
			agent.SetDestination (target.transform.position);
			myani.Play ("Run");

		} else if (Mushhp <= 0 && a == 1) {
			myani.Play ("Death");
			//Destroy (this.gameObject);
			a++;
			//Destroy (this.gameObject);
		} else if (a == 40) {
			target.GetComponent<PlayerController> ().diedMon++;
			//Debug.Log (target.GetComponent<PlayerController> ().diedMon);
			Destroy (this.gameObject);
		} else {
			a++;
		}

		if (this.transform.position.y < -10.0f) {
			Destroy (this.gameObject);
		}
	}
		/*
		// ターゲット方向のベクトルを求める
		Vector3 vec = target.position - transform.position;
		// ターゲットの方向を向く
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), rotMax);
		transform.Translate(Vector3.forward * speed); // 正面方向に移動
	}*/

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "igaguri") {
			Mushhp -= igaguriatk;
			Destroy (col.gameObject);
		}
	}

/*void OnCollisionEnter(Collision hit){ 
		//Debug.Log ("あ");
	if (hit.gameObject.tag=="TokushuIga"){
		Debug.Log ("あ");
		hp -= igaguriatk;
	 }
	}*/
}
