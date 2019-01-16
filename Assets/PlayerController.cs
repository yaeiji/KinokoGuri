using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	Rigidbody rigid;
	public readonly int maxHP = 100;    //体力の最大値
	public int HP;    //体力
	public int EnemyATK = 10;//敵の攻撃力
	public int KingATK=50;
	private int a=0;
	private GameObject gameOverText;
	private GameObject DiedCountText;
	private GameObject spaceText;
	public int diedMon=0;
	private string Rank="D";
	private int Textcon=0;
	public AudioClip damage;
	private float speed =7.0f;
	public GameObject moun;
	public GameObject itemGenerator;
	public bool Tokushu1=false;
	public GameObject Tokushu1Iga;
	public AudioClip Tkushukouka;
	public GameObject IgaArmor;

	public bool BGMkirikae=true;
	public bool BGMkirikae2=true;
	private GameObject BGM1;
	private GameObject BGM2;

	private bool tokushuhyoji=false;
	public GameObject to;

	public float Tokushu1Time;
	private GameObject IgArmor;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		HP = maxHP; //初期体力を最大値にする
		this.gameOverText=GameObject.Find("GameOver");
		this.DiedCountText = GameObject.Find ("DiedEnemyCount");
		this.spaceText = GameObject.Find ("SpaceText");
		this.moun = GameObject.Find ("Moutainarea");
		this.itemGenerator = GameObject.Find ("ItemGenerator");
		this.BGM1 = GameObject.Find ("BGM");
		this.BGM2 = GameObject.Find ("BGM2");
		Tokushu1Iga.SetActive (false);
		BGM1.SetActive (false);
		BGM2.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		OnchangeBGM ();

		if (Tokushu1 == true) {
			
			if (tokushuhyoji == false) {
			    IgArmor = Instantiate (IgaArmor) as GameObject;
				Tokushu1Iga.SetActive (true);
				tokushuhyoji = true;
				Time.timeScale = 0f;
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				Time.timeScale = 1.0f;
				Destroy (IgArmor.gameObject);
			}

			Tokushu1Time += Time.deltaTime;
			if (Tokushu1Time >= 30.0f) {
				Tokushu1Time = 0f;
				Tokushu1 = false;
				Tokushu1Iga.SetActive  (false);
				tokushuhyoji = false;
			}
		}

		if (this.transform.position.y < -10.0f) {
			HP = 0;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (0.0f, 1.0f, 0.0f));
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (0.0f, -1.0f, 0.0f));
		}

		//wasdで移動する
		float x =0.0f;
		float z = 0.0f;

		if (Input.GetKey (KeyCode.D)) {
			x += speed;
		}
		if (Input.GetKey (KeyCode.A)) {
			x -= speed;
		}
		if (Input.GetKey (KeyCode.W)) {
			z += speed;
		}
		if (Input.GetKey (KeyCode.S)) {
			z -= speed;
		}

		rigid.velocity =z * transform.forward + x * transform.right;

		if (diedMon == 100) {
			Rank = "S";
		} 
	    if (diedMon==50) {
			Rank="A";
		}

		if (diedMon == 25) {
			Rank="B";
		}
		
		if (diedMon == 10) {
			Rank="C";
		}

		if (HP <= 0){
			if (Textcon == 0) {
				gameOverText.GetComponent<Text> ().text = "GAMEOVER";
				Textcon++;
				spaceText.GetComponent<Text> ().text = "spaceキーを押してね>>>>>>>";
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				gameOverText.GetComponent<Text>().text=" ";
				DiedCountText.GetComponent<Text> ().text = "あなたが倒した敵の数：" + diedMon+"\n"+"ランク："+Rank;
				Textcon++;
				if (Input.GetKeyUp (KeyCode.Space)) {
					Textcon++;
				}
				if (Input.GetKeyDown (KeyCode.Space) && Textcon==3) {
						SceneManager.LoadScene ("TitleScene");
					
				}
			}
		}
	}

	void OnCollisionEnter(Collision hit){ 
		
		if (hit.gameObject.tag=="enemy"){
			if(Tokushu1==false){
				GetComponent<AudioSource> ().Play ();

				HP -= EnemyATK; //攻撃で体力が減少
				//Debug.Log(HP); //HPを表示
			}else if(Tokushu1==true){
				hit.gameObject.GetComponent<MushController> ().Mushhp -= 50;
			}
		}
		if (hit.gameObject.tag=="King"){
			if(Tokushu1==false){
			GetComponent<AudioSource> ().Play ();

			HP -= KingATK; //攻撃で体力が減少
			//Debug.Log(HP); //HPを表示
			}else if(Tokushu1==true){
				hit.gameObject.GetComponent<KingMushController> ().Kinghp -= 50;

			}
		}

	}
	void OnCollisionStay(Collision hit){ 
		
		if (hit.gameObject.tag == "enemy") {
			a++;
			if (a == 30) {
				if (Tokushu1 == false) {
					GetComponent<AudioSource> ().Play ();
					HP -= EnemyATK; //攻撃で体力が減少
					//Debug.Log (HP); //HPを表示
					a = 0;
				} else if (Tokushu1 == true) {
					hit.gameObject.GetComponent<MushController> ().Mushhp -= 50;
				}
		
			}
		}
		if (hit.gameObject.tag=="King"){
			a++;
			if(a==30){
				if(Tokushu1==false){
			GetComponent<AudioSource> ().Play ();

			HP -= KingATK; //攻撃で体力が減少
			//Debug.Log(HP); //HPを表示
				}else if(Tokushu1==true){
					hit.gameObject.GetComponent<KingMushController> ().Kinghp -= 50;
				}
			}
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "ha") {
			itemGenerator.GetComponent<ItemGenarator> ().hantei = false;
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "ha") {
			itemGenerator.GetComponent<ItemGenarator> ().hantei = true;
		}
	}

	public void OnchangeBGM(){
		if (BGMkirikae != BGMkirikae2) {
		//	Debug.Log ("い");
			if (BGMkirikae == true) {
				BGM1.SetActive (true);
				BGM2.SetActive (false);
				BGMkirikae = false;
			} else if (BGMkirikae == false) {
		//		Debug.Log ("あ");
				BGM1.SetActive (false);
				BGM2.SetActive (true);
				BGMkirikae = true;
			}
		}
	}

}
