using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour {
	public int HP;
	int hpmax = 0;
	public Slider slid;

	public int s2 = 0;

	public Text hpc;

	float tf = 0;
	int lck = 0;

	// Use this for initialization
	void Start () {
		hpmax = HP;
	}

	void OnTriggerStay2D(Collider2D hitInfo)
	{

		Debug.Log (hitInfo.name);
		if (!Input.GetMouseButton (0)) {
			GameObject obj = GameObject.Find(hitInfo.name);
			GameObject childA = obj.gameObject.transform.GetChild (3).gameObject;
			GameObject childE = obj.gameObject.transform.GetChild (4).gameObject;

			Debug.Log (childA.GetComponent<Text>().text);

			Action (childE, childA, obj);

		}

	}
		

	public void Action(GameObject childE, GameObject childA, GameObject obj)
	{
		GameObject mang = GameObject.Find ("PlayerMng");
		int energy = 0;
		int isheal = 0;
		int amount = mang.GetComponent<PlayerMang> ().getEng ();
		if (childA.GetComponent<Text> ().text.Contains ("+")) {
			
			energy = int.Parse (childE.GetComponent<Text> ().text);
			isheal = 1;
		} else {
			energy = int.Parse (childE.GetComponent<Text> ().text);
			isheal = 0;
		}

		if (amount - energy >= 0) {
			if (isheal == 1) {
				GameObject player2 = GameObject.Find ("PlayerMng");
				string heal = childA.GetComponent<Text> ().text.Remove (0, 1);
				player2.GetComponent<PlayerMang>().hp += int.Parse(heal);
			} else {
				TakeDMG (int.Parse (childA.GetComponent<Text> ().text));
			}
			mang.GetComponent<PlayerMang> ().dmgEnergy (energy);
			Destroy (obj);
			GameObject player = GameObject.Find ("PlayerMng");
			//Debug.Log ("d "+(obj.name.Length - 1));
			obj.name = obj.name.Replace ("(Clone)", "");
			string name = obj.name.Remove (obj.name.Length - 1, 1);
			Debug.Log ("ss"+name);
			player.GetComponent<PlayerMang>().Deck.Enqueue (name);
		}
	}

	public void TakeDMG(int dmage)
	{
		if (HP-dmage <= 0) {
			if (s2 == 1) {
				HP += 200;
				gameObject.GetComponent<SpriteRenderer> ().color = Color.magenta;
				GameObject name = GameObject.FindWithTag ("mudkip");
				if (scene.lvl == 7) {
					name.GetComponent<Text> ().text = "Angry Evil Mudkip";
					gameObject.GetComponent<dmgMon> ().dmg = 100;
				} else if(scene.lvl == 20) {
					HP += 100;
					name.GetComponent<Text> ().text = "Angry Evil Agoz";
					gameObject.GetComponent<dmgMon> ().dmg = 150;
                }else if (scene.lvl == 35)
				{
					HP += 200;
					name.GetComponent<Text>().text = "Angry Evil Mango";
					gameObject.GetComponent<dmgMon>().dmg = 250;
				}


				s2 = 0;
			} else {
				GameObject player = GameObject.Find ("PlayerMng");
				player.GetComponent<PlayerMang> ().lck = 1;
				player.GetComponent<PlayerMang> ().tf = 3f;
				SaveManger.Instance.state.hp = player.GetComponent<PlayerMang> ().hp;
				Destroy (gameObject);
			}

		} else {
			HP -= dmage;
		}
	}

	// Update is called once per frame
	void Update () {
		slid.maxValue = hpmax;
		slid.value = HP;

		hpc.text = HP + "/" + hpmax;

		if (tf > 0) {
			tf -= Time.deltaTime;
		} else if(lck == 1){
			if (scene.lvl != 8) {
				//SceneManager.LoadScene (sceneName: "Start");
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			HP = 1;
		}

	}
}
