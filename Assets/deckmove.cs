using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deckmove : MonoBehaviour {

	public GameObject cam;
	public Slider slid;
	public int cardscount2 = 0;
	//public Canvas can;



	// Use this for initialization
	void Start () {
		

		//cam.transform.position = scene.campos;
	}




	// Update is called once per frame
	void Update () {
		
		string[] cards = SaveManger.Instance.state.gold.Split ('#');
		cardscount2 = cards.Length;

		slid.maxValue =9 +(18.5f * (cardscount2 / 3.5f));
		cam.transform.position = new Vector2(cam.transform.position.x, 160+slid.value*10);



	}
}
