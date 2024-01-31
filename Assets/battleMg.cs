using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleMg : MonoBehaviour {
	int a = 0;
	// Use this for initialization
	void Start () {
		System.Random rnd = new System.Random ();
		string monName = "";
		if (scene.lvl <= 10) {
			int n = rnd.Next (1, 8);
			monName = "bad" + n;
			if (scene.lvl == 4) {
				monName = "bad9";
			}
			if (scene.lvl == 7) {
				monName = "bad8";
			}
		} else if(scene.lvl > 10 && scene.lvl <= 22) {
			int n = rnd.Next (11, 16);
			monName = "bad" + n;
			if (scene.lvl == 13) {
				monName = "bad10";
			}
			if (scene.lvl == 18) {
				monName = "bad10";
			}
			if (scene.lvl == 20) {
				monName = "bad16";
			}
		}else
        {
			int n = rnd.Next(18, 23);
			monName = "bad" + n;
			if (scene.lvl == 24)
			{
				monName = "bad17";
			}
			if (scene.lvl == 27)
			{
				monName = "bad17";
			}
			if (scene.lvl == 32)
			{
				monName = "bad17";
			}
			if (scene.lvl == 35)
			{
				monName = "bad23";
			}
		}
		Debug.Log (monName);
		GameObject summPoint = GameObject.Find ("MonPoint");
		//GameObject summPoint2 = GameObject.Find ("Canvas (4)");
		GameObject mon = Resources.Load<GameObject> ("Enemys/" + monName).gameObject;
		if (scene.lvl == 7 || scene.lvl == 20 || scene.lvl == 35) {
			string[] arry = SaveManger.Instance.state.gold.Split ('#');
			for (int i = 0; i < arry.Length; i++) {
				if (arry[i] == "FirKunO" || arry[i] == "ValenO" || arry[i] == "SpicyO") {
					mon.GetComponent<Heart> ().s2 = 1;
				}
			}
		}
		//mon.name = cardName + "4";
		//mon.GetComponent<DragDrop> ().core = "4";
		//mon.GetComponent<DragDrop> ().b = 0;
		//mon.transform.localScale = new Vector3(1f, 1f, 0);
		Instantiate (mon, summPoint.transform.position, Quaternion.identity);
		endturn ();
	}

	public void endturn()
	{
		GameObject player = GameObject.Find ("PlayerMng");
		GameObject[] enemys = GameObject.FindGameObjectsWithTag ("monster");
		int amount = 0;
		for (int i = 0; i < enemys.Length; i++) {
			amount += enemys [i].GetComponent<dmgMon> ().dmg;
		}
		if (a == 1) {
			player.GetComponent<PlayerMang> ().TakeDmg (amount);
			if (scene.lvl == 4 || scene.lvl == 13 || scene.lvl == 18 || scene.lvl == 24 || scene.lvl == 27 || scene.lvl == 32) {
				enemys [0].GetComponent<Heart> ().TakeDMG (1);
			}
		}
		player.GetComponent<PlayerMang> ().enegry = player.GetComponent<PlayerMang> ().engmax;
		player.GetComponent<PlayerMang> ().popADeck ();
		a = 1;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
