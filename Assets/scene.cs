using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene : MonoBehaviour {
	public static int lvl = 0;
	public int show = 0;
	public int lckk = 0;
	public GameObject can;
	public GameObject candis;

	public int cardscount = 0;
	public static int isindeck = 0;

	public static Vector3 campos = new Vector3(6, -3, -10);

	public Vector3 campos2;

	public GameObject scenee;

	public Vector2 pointsss;

	public int x;
	public int y;

	List<string> cards = new List<string>();
	string[] array = new string[]
	{"Slash",
		"SlashG",
		"Strike", 
		"StrikeG" ,
		"StrikeB" ,
		"SmiteL",
		"FireFistG",
		"Punch",
		"PunchB",
		"FireballL",
		"RestG", 
		"LunchB",
		"RockG", 
		"DefendL",
		"Selfheal", 
		"ShieldG",
		"ShieldB",
		"Smash", 
		"SmashB",
		"BackstabL",
		"PowerTwoL",
		"Stab",
		"StabB",
		"StabG",
		"StabB",
		"FirKunO",
		"ValenO",
		"SpicyO"
		};

	// Use this for initialization
	void Start () {
		//can = GameObject.Find ("Canvas (2)");
		GameObject cam = GameObject.Find ("Main Camera");
		campos = cam.transform.position;
	}

	public void Pick1(int index)
	{
		string cards2 = SaveManger.Instance.state.gold;
		cards2 += "#" + cards [index];
		SaveManger.Instance.state.gold = cards2;
		SaveManger.Instance.Save ();

		can.SetActive (false);
	}
		

	public void Ok()
	{
		scenee.SetActive (false);
	}

	public void cardsnum()
	{
		string[] cards = SaveManger.Instance.state.gold.Split ('#');
		cardscount = cards.Length;
	}

	public void closemedeck()
	{
		isindeck = 0;

		GameObject slid = GameObject.Find ("SliderMe");
		slid.GetComponent<Slider> ().value = 0;
		GameObject summPoint2 = GameObject.Find ("Decks");
		summPoint2.transform.transform.position = pointsss;
		string[] desk = SaveManger.Instance.state.gold.Split('#');
		for (int j = 0; j < desk.Length; j++) {
			Destroy(GameObject.Find("Me"+ j+"(Clone)"));
			Destroy(GameObject.Find("MeMo"+ j));
		}
		Destroy (GameObject.Find ("Kard0"));
		candis.SetActive (false);

	}

	public void showmedeck()
	{
		isindeck = 1;
		GameObject.Find ("Main Camera").transform.position = new Vector3 (GameObject.Find ("Main Camera").transform.position.x, 42, -10);
		candis.SetActive (true);
		string[] desk = SaveManger.Instance.state.gold.Split('#');

		for (int i = 0; i < desk.Length; i++) {
			cards.Add (desk[i]);
		}

		GameObject summPoint = GameObject.Find ("MeM");
		x = (int)summPoint.transform.position.x;
		y = (int)summPoint.transform.position.y;
		GameObject summPoint2 = GameObject.Find ("Decks");
		pointsss = summPoint2.transform.transform.position;
		GameObject cardos = new GameObject();
		List<GameObject> points = new List<GameObject> ();

		cardos.name = "Kard0";
		for (int j = 1; j < desk.Length+1; j++) {
			
			points.Add (new GameObject ());
			points [points.Count - 1].name = "MeMo" + (points.Count - 1);
			points [points.Count - 1].transform.position = new Vector3 (x, y, 0);


			cardos = Resources.Load<GameObject> ("Cards/" + cards [j-1]).gameObject;
			cardos.name = "Me"+ (points.Count - 1);
			cardos.GetComponent<DragDrop> ().b = 1;
			cardos.GetComponent<DragDrop> ().no = 1;
			cardos.GetComponent<DragDrop> ().core = "MeMo" + (points.Count - 1);
			cardos.transform.position = summPoint.transform.position;
			cardos.transform.localScale = new Vector3 (0.2f, 0.2f, 0);
			Instantiate (cardos, summPoint2.transform, false);

			if (j % 4 == 0 && j != 0) {
				
				x = (int)summPoint.transform.position.x;
				y -= 350;

			} else {
				x += 200;
			}
		}
	}


	public void load()
	{
		GameObject cam = GameObject.Find ("Main Camera");
		campos = cam.transform.position;
		SceneManager.LoadScene (sceneName: "Battle");
	}

	// Update is called once per frame
	void Update () {
		campos2 = campos;
		cardsnum ();
		if (scene.lvl > 0) {
			scenee.SetActive (false);
		}


		show = lvl;
		if (lvl == 0) {
			GameObject btn = GameObject.Find("Button");
			btn.GetComponent<Button> ().interactable = true;
		} else {
			GameObject btn = GameObject.Find("Button (" + lvl + ")");
			btn.GetComponent<Button> ().interactable = true;
		}

		if (lvl != 0 && lvl % 1 == 0 && lckk == 0 && cardscount < (12+lvl)) {
			can.SetActive (true);
			System.Random rnd = new System.Random ();
			int n = 0; 

			for (int i = 0; i < 3; i++) {
				n = rnd.Next (0, array.Length);
				cards.Add (array [n]);
			}

			GameObject summPoint = GameObject.Find ("1");
			GameObject summPoint2 = GameObject.Find ("Canvas (2)");
			GameObject mon = Resources.Load<GameObject> ("Cards/" + cards[0]).gameObject;

			mon.GetComponent<DragDrop> ().b = 1;
			mon.GetComponent<DragDrop> ().core = "1";
			mon.transform.position = summPoint.transform.position;
			mon.transform.localScale = new Vector3(0.2f, 0.2f, 0);
			Instantiate (mon, summPoint2.transform, false);

			summPoint = GameObject.Find ("2");
			summPoint2 = GameObject.Find ("Canvas (2)");
			GameObject mon2 = Resources.Load<GameObject> ("Cards/" + cards[1]).gameObject;

			mon2.GetComponent<DragDrop> ().b = 1;
			mon2.GetComponent<DragDrop> ().core = "2";
			mon2.transform.position = summPoint.transform.position;
			mon2.transform.localScale = new Vector3(0.2f, 0.2f, 0);
			Instantiate (mon2, summPoint2.transform, false);

			summPoint = GameObject.Find ("3");
			summPoint2 = GameObject.Find ("Canvas (2)");
			GameObject mon3 = Resources.Load<GameObject> ("Cards/" + cards[2]).gameObject;

			mon3.GetComponent<DragDrop> ().b = 1;
			mon3.GetComponent<DragDrop> ().core = "3";
			mon3.transform.position = summPoint.transform.position;
			mon3.transform.localScale = new Vector3(0.2f, 0.2f, 0);
			Instantiate (mon3, summPoint2.transform, false);

			lckk = 1;
		}
	}
}
