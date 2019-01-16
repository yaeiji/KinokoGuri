using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KingMushController : MonoBehaviour {
	public GameObject target; // 追いかける対象
	private NavMeshAgent agent;
	private Animation myani;
	public GameObject target1;
	private GameObject target2;
	private float an=5.0f;

	public int Kinghp = 2000;
	private int igaguriatk=50;
	private int a = 1;

	// Use this for initialization
	void Start () {
		
		agent=GetComponent<NavMeshAgent> ();
		myani = this.gameObject.GetComponent<Animation> ();
		target = GameObject.Find ("Main Camera");
		target2 = GameObject.Find ("KingRange");
	}
	
	// Update is called once per frame
	void Update () {
		an += Time.deltaTime;

		if (Kinghp > 0) {
			if (target1 == null) {
				myani.Play ("Idle");
			} else if (this.transform.position.z < 0 && this.transform.position.x > 0 &&an>2.0f) {
				agent.SetDestination (target1.transform.position);
				myani.Play ("Run");
			} else {
				agent.SetDestination (target2.transform.position);
				myani.Play ("Run");
				target.GetComponent<PlayerController> ().BGMkirikae2 = true;
				an = 0.0f;
			}

		} else if (Kinghp <= 0 && a == 1) {
			myani.Play ("Death");
			//Destroy (this.gameObject);
			a++;
			//Destroy (this.gameObject);
		} else if (a == 40) {
			target.GetComponent<PlayerController> ().diedMon+=100;
			//Debug.Log (target.GetComponent<PlayerController> ().diedMon);
			Destroy (this.gameObject);
		} else {
			a++;
		}

		if (this.transform.position.y < -10.0f) {
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "igaguri") {
			Kinghp -= igaguriatk;
			Destroy (col.gameObject);
		}
		/*if (col.gameObject.tag == "KingRange") {
			target1=col.gameObject;
		}*/
	}

/*	void OnCollisionEnter(Collision hit){ 

		if (hit.gameObject.tag=="TokushuIga"){
			hp -= igaguriatk;
		}
	}*/
/*	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "KingRange") {
			target2=col.gameObject;
		}
	}
*/
}
