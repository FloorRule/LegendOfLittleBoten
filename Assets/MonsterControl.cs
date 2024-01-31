using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterControl : MonoBehaviour {

	Rigidbody2D rb;
	GameObject target;
	float moveSpeed;
	Vector3 directionToTarget;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("goose");
		rb = GetComponent<Rigidbody2D> ();
		moveSpeed = 1000f;
	}



	// Update is called once per frame
	void Update () {

		if (Math.Abs(Math.Sqrt ((Math.Pow (this.transform.position.x - target.transform.position.x, 2) + Math.Pow (this.transform.position.y - target.transform.position.y, 2))))< 10) {
			moveSpeed = 0;
		} else {
			moveSpeed = 1000f;
		}

		MoveMonster ();
	}

	void MoveMonster ()
	{
		if (target != null) {
			directionToTarget = (target.transform.position - transform.position).normalized;
			rb.velocity = new Vector2 (directionToTarget.x * moveSpeed,
										directionToTarget.y * moveSpeed);
		}
		else
			rb.velocity = Vector3.zero;
	}
}
