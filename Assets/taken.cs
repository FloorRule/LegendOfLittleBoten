using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taken : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerStay2D(Collider2D hitInfo)
	{
		if (hitInfo.tag == "card" && hitInfo.name.Contains("1")) {
			GameObject mg = GameObject.Find ("Busy");
			mg.GetComponent<busyMang> ().manger ("1", 1);
		}else if (hitInfo.tag == "card" && hitInfo.name.Contains("2")) {
			GameObject mg = GameObject.Find ("Busy");
			mg.GetComponent<busyMang> ().manger ("2", 1);
		}else if (hitInfo.tag == "card" && hitInfo.name.Contains("3")) {
			GameObject mg = GameObject.Find ("Busy");
			mg.GetComponent<busyMang> ().manger ("3", 1);
		}else if (hitInfo.tag == "card" && hitInfo.name.Contains("4")) {
			GameObject mg = GameObject.Find ("Busy");
			mg.GetComponent<busyMang> ().manger ("4", 1);
		}

	}

	void OnTriggerExit2D(Collider2D hitInfo)
	{
		if (hitInfo.tag == "card" && hitInfo.name.Contains("1")) {
			GameObject mg = GameObject.Find ("Busy");
			mg.GetComponent<busyMang> ().manger ("1", 0);
		}else if (hitInfo.tag == "card" && hitInfo.name.Contains("2")) {
			GameObject mg = GameObject.Find ("Busy");
			mg.GetComponent<busyMang> ().manger ("2", 0);
		}else if (hitInfo.tag == "card" && hitInfo.name.Contains("3")) {
			GameObject mg = GameObject.Find ("Busy");
			mg.GetComponent<busyMang> ().manger ("3", 0);
		}else if (hitInfo.tag == "card" && hitInfo.name.Contains("4")) {
			GameObject mg = GameObject.Find ("Busy");
			mg.GetComponent<busyMang> ().manger ("4", 0);
		}
	}



	// Update is called once per frame
	void Update () {
		
	}
}
