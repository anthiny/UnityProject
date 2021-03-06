﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePatternBoss01 : MovePatternParent {
	public GameObject target;
	[SerializeField]
	private bool checkPoint = false;
	void Start(){
		target = GameObject.FindGameObjectWithTag("Player");
	}
	override public void Move(){
		if(checkPoint){
			FollowTargetInX();
		}
		else{
			GoToPoint();
		}
	}

	private void GoToPoint(){
		if(gameObject.transform.position.y <= 4){
			checkPoint = true;
		}
		gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * 1;
	}

	private void FollowTargetInX(){
		if(Mathf.Abs(target.transform.position.x-transform.position.x) > 0.1){
			Vector2 direction = target.transform.position - transform.position;
			direction.y = 0;
			direction.Normalize();
			gameObject.GetComponent<Rigidbody2D>().velocity = direction * movementSpeed;
		}
		else{
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
		}
	}

}
