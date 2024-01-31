using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class busyMang : MonoBehaviour {

	public int one = 0;
	public int two = 0;
	public int three = 0;
	public int four = 0;

	// Use this for initialization
	void Start () {
		
	}

	public void manger(string name, int state)
	{
		int n = int.Parse (name);
		switch (n) {
		case 1:
			one = state;
			break;
		case 2:
			two = state;
			break;
		case 3:
			three = state;
			break;
		case 4:
			four = state;
			break;
		default:
			break;
		}
	}

	public void end()
	{
		SceneManager.LoadScene (sceneName: "Start");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
