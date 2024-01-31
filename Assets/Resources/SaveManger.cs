using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManger : MonoBehaviour {

	public static SaveManger Instance { set; get; }
	public SaveState state;

	string[] array = new string[]
	{"Slash", "Slash", "Slash", "SlashG", 
		"Strike","Strike", "Strike", 
		"FireFistG",
		"Punch", "Punch","Punch", 
		"RestG", 
		"RockG", 
		"Selfheal", "Selfheal", "Selfheal", 
		"ShieldG", 
		"Smash", "Smash", 
		"SmashB",
		"Stab", "Stab", "Stab",
		"StabG", 
		"StrikeG"};

	private void Awake()
	{
		DontDestroyOnLoad (gameObject);
		Instance = this;
		Load ();

		Debug.Log (Helper.Serailize<SaveState> (state));
	}

	public void Save()
	{
		PlayerPrefs.SetString ("save4", Helper.Serailize<SaveState> (state));
	}

	public void newSave()
	{
		state = new SaveState();
		state.hp = 100;
		System.Random rnd = new System.Random ();
		int n = 0; 
		string cards = "";
		for (int i = 0; i < 12; i++) {//add more cards
			n = rnd.Next (0, array.Length);
			if (i != 11) {
				cards += array [n] + "#";
			} else {
				cards += array [n];
			}
		}
		state.gold = cards;
		state.lvl = 0;
		Save();
		Debug.Log("make new");
	}


	public void Load()
	{
		if (PlayerPrefs.HasKey ("save4")) {
			state = Helper.Deserialize<SaveState> (PlayerPrefs.GetString ("save4"));
			scene.lvl = state.lvl;

		}else
		{
			state = new SaveState();
			state.hp = 100;
			System.Random rnd = new System.Random ();
			int n = 0; 
			string cards = "";
			for (int i = 0; i < 12; i++) {
				n = rnd.Next (0, array.Length);
				if (i != 11) {
					cards += array [n] + "#";
				} else {
					cards += array [n];
				}
			}
			state.gold = cards;
			state.lvl = 0;
			Save();
			Debug.Log("make new");
		}
	}



	public string getstare()
	{
		return state.gold;
	}

}
