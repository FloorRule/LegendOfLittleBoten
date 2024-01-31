using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

	public Camera cam;
	public Canvas can;
	public float newpow;
	public float newpowy;

	public float dragSpeed = 1;
	public Vector3 dragOrigin;
	int xbo = 70;
	Vector3 worldPosition;
	// Use this for initialization
	void Start () {
		cam.orthographicSize = 862;

		if(scene.lvl >= 23)
        {
			xbo = 2850;
		}
		else if (scene.lvl > 10 && scene.lvl <= 22) {
			xbo = 1450;
		} else {
			xbo = 70;
		}

		cam.transform.position = scene.campos;
	}


	public void zoom()
	{
		if(cam.orthographicSize < 800)
		{
			cam.orthographicSize = cam.orthographicSize + 200;
		}



	}

	public void zoomout()
	{
		if(cam.orthographicSize > 400)
		{
			cam.orthographicSize = cam.orthographicSize - 200;
		}

	}

	// Update is called once per frame
	void Update () {
		
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Camera.main.nearClipPlane;
		worldPosition = Camera.main.ScreenToWorldPoint(mousePos);


		if (Input.GetMouseButtonDown(0) && scene.isindeck == 0)
		{
			dragOrigin = Input.mousePosition;

			return;
		}

		if (!Input.GetMouseButton (0)) {
			if (cam.transform.position.x > xbo) {
				cam.transform.position = new Vector3 (xbo, cam.transform.position.y, -10);
			}
			if (cam.transform.position.x < -60) {
				cam.transform.position = new Vector3 (-60, cam.transform.position.y, -10);
			}
			if (cam.transform.position.y > 280) {
				cam.transform.position = new Vector3 (cam.transform.position.x, 280, -10);
			}
			if (cam.transform.position.y < -180) {
				cam.transform.position = new Vector3 (cam.transform.position.x, -180, -10);
			}
			return;
		}


		Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		newpow = pos.x * dragSpeed;
		newpow *= (-1);
		newpowy = pos.y * dragSpeed;
		newpowy *= (-1);

		if (cam.transform.position.x > xbo && newpow > 0) {
			newpow = 0;
			//cam.transform.position = new Vector3(44, cam.transform.position.y, -10);
		}
		if (cam.transform.position.x < -60 && newpow < 0) {
			newpow = 0;
			//cam.transform.position = new Vector3(44, cam.transform.position.y, -10);
		}

		if (cam.transform.position.y > 280 && newpowy > 0) {
			newpowy = 0;
			//cam.transform.position = new Vector3(44, cam.transform.position.y, -10);
		}
		if (cam.transform.position.y < -180 && newpowy < 0) {
			newpowy = 0;
			//cam.transform.position = new Vector3(44, cam.transform.position.y, -10);
		}
		Vector3 move = new Vector3(newpow, newpowy, 0);

		if (scene.isindeck == 0) {
			transform.Translate (move, Space.World);
		}  



	}
}
