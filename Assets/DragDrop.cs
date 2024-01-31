using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

	private bool isDrag;
	public string core;
	public int a = 0;
	public int no = 0;
	public int b = 0;
	void Start()
	{
		
		//ancor = GameObject.Find ("Canvas-"+ancorName);
		//childs = ancor.transform.GetChild (index - 1).gameObject;
		//pos = childs.transform.position;
	}


	public void OnBeginDrag(PointerEventData eventData)
	{
		//ancor = GameObject.Find ("Canvas-"+ancorName);
		//childs = ancor.transform.GetChild (index - 1).gameObject;
		//pos = childs.transform.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (Input.GetKey(KeyCode.Mouse0) && no == 0) {
			
			isDrag = true;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (no == 0) {
			isDrag = false;
			gameObject.transform.position = GameObject.Find (core).transform.position;
		}
		//gameObject.transform.position = pos;
		 
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		//gameObject.transform.position = pos;

	}





	void FixedUpdate()
	{
		if (a == 1) {
			gameObject.transform.position = GameObject.Find (core).transform.position;
			a = 0;
		}
		if (isDrag && b == 0) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
			transform.Translate (mousePos);
		}
	}

}
