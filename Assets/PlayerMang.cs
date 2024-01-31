using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMang : MonoBehaviour {
	public Slider hpslid;
	public Slider engslid;
	public static int hp2;
	public int hp;
	int hpmax;
	public int enegry;
	public int engmax;

	public Text count;
	public Text countE;
	public Text countH;

	public Queue<string> Deck = new Queue<string>();

	public static int cardnum = 0;

	public float tf = 0;
	public int lck = 0;

	public GameObject Death;
	public GameObject Vic;
	public GameObject Mid;
	public GameObject Mid2;
	public int death = 0;

	// Use this for initialization
	void Start () {
		death = 0;
		SaveManger.Instance.Load ();
		Debug.Log (SaveManger.Instance.state.gold);
		hp = SaveManger.Instance.state.hp;
		string[] arry = SaveManger.Instance.state.gold.Split ('#');
		arry = Shuffle (arry);
		for (int i = 0; i < arry.Length; i++) {
			Deck.Enqueue (arry [i]);
		}
		hpmax = hp;
		hp2 = hp;
		engmax = enegry;
	}

	public string[] Shuffle(string[] decklist) {
		string tempGO = "";
		for (int i = 0; i < decklist.Length; i++) {
			int rnd = Random.Range(0, decklist.Length);
			tempGO = decklist[rnd];
			decklist[rnd] = decklist[i];
			decklist[i] = tempGO;
		}
		return decklist;
	}

	public void popADeck()
	{
		GameObject mg = GameObject.Find ("Busy");
		string cardName = "";
		if (mg.GetComponent<busyMang> ().four == 0) {
			cardName = Deck.Dequeue ();

			GameObject summPoint = GameObject.Find ("4");
			GameObject summPoint2 = GameObject.Find ("Canvas (4)");
			GameObject mon = Resources.Load<GameObject> ("Cards/" + cardName).gameObject;
			mon.name = cardName + "4";
			mon.GetComponent<DragDrop> ().core = "4";
			mon.GetComponent<DragDrop> ().b = 0;
			mon.GetComponent<DragDrop> ().no = 0;
			mon.transform.localScale = new Vector3(1f, 1f, 0);
			Instantiate (mon, summPoint2.transform, false);
			//mon.transform.position = summPoint.transform.position;


		}
		if (mg.GetComponent<busyMang> ().three == 0) {
			cardName = Deck.Dequeue ();

			GameObject summPoint = GameObject.Find ("3");
			GameObject summPoint2 = GameObject.Find ("Canvas (3)");
			GameObject mon = Resources.Load<GameObject> ("Cards/" + cardName).gameObject;
			mon.name = cardName + "3";
			mon.GetComponent<DragDrop> ().core = "3";
			mon.GetComponent<DragDrop> ().b = 0;
			mon.GetComponent<DragDrop> ().no = 0;
			mon.transform.localScale = new Vector3(1f, 1f, 0);
			Instantiate (mon, summPoint2.transform, false);
			//mon.transform.position = summPoint.transform.position;


		}
		if (mg.GetComponent<busyMang> ().two == 0) {
			cardName = Deck.Dequeue ();

			GameObject summPoint = GameObject.Find ("2");
			GameObject summPoint2 = GameObject.Find ("Canvas (2)");
			GameObject mon = Resources.Load<GameObject> ("Cards/" + cardName).gameObject;
			mon.name = cardName + "2";
			mon.GetComponent<DragDrop> ().core = "2";
			mon.GetComponent<DragDrop> ().b = 0;
			mon.GetComponent<DragDrop> ().no = 0;
			mon.transform.localScale = new Vector3(1f, 1f, 0);
			Instantiate (mon, summPoint2.transform, false);
			///mon.transform.position = summPoint.transform.position;


		}
		if (mg.GetComponent<busyMang> ().one == 0) {
			cardName = Deck.Dequeue ();
			Debug.Log (cardName);
			GameObject summPoint = GameObject.Find ("1");
			GameObject summPoint2 = GameObject.Find ("Canvas (1)");
			GameObject mon = Resources.Load<GameObject> ("Cards/" + cardName).gameObject;
			mon.name = cardName + "1";
			mon.GetComponent<DragDrop> ().core = "1";
			mon.GetComponent<DragDrop> ().b = 0;
			mon.GetComponent<DragDrop> ().no = 0;
			mon.transform.localScale = new Vector3(1f, 1f, 0);
			mon.transform.position = summPoint.transform.position;
			Instantiate (mon, summPoint2.transform, false);
			mon.GetComponent<DragDrop> ().a = 1;


		}
	}

	public int getEng()
	{
		return enegry;
	}

	public void dmgEnergy(int cost)
	{
		enegry -= cost;
	}

	public void TakeDmg(int dmg)
	{
		if (hp - dmg > 0) {
			hp -= dmg;
		} else {
			death = 1;
			lck = 1;
			tf = 3;

			Debug.Log ("Player DEAD");

		}
	}



	// Update is called once per frame
	void Update () {
		hp2 = hp;
		count.text = Deck.Count.ToString ();
		cardnum = Deck.Count + 4;
		hpslid.maxValue = hpmax;
		hpslid.value = hp;

		engslid.maxValue = engmax;
		engslid.value = enegry;

		countH.text = hp + "/" + hpmax;
		countE.text = enegry + "/" + engmax;

		if (tf > 0) {
			tf -= Time.deltaTime;
		} else if(lck == 1){
			if (death == 1) {
				SaveManger.Instance.newSave ();
			} else {
				scene.lvl += 1;
				SaveManger.Instance.state.lvl = scene.lvl;
				SaveManger.Instance.Save ();
			}
			if (scene.lvl != 36) {
				if (scene.lvl == 8)
				{
					Mid.SetActive(true);
					lck = 0;
				} else if (scene.lvl == 21)
				{
					Mid2.SetActive(true);
					lck = 0;
				}else {
					SceneManager.LoadScene (sceneName: "Start");
				}
			} else {
				
				Vic.SetActive (true);

				SaveManger.Instance.newSave ();

				lck = 0;
			}

		}
		if (death == 1) {
			Death.SetActive (true);
		} else {
			Death.SetActive (false);
		}


	}
}
