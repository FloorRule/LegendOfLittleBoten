using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void Getin()
	{
		SceneManager.LoadScene (sceneName: "Start");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
