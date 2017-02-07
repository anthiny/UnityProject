﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;

	public GameObject bullet;
	public GameObject[] effectList;
	public Transform target;
	public int curHp; 
	public void Update(){
		Attack();
		Move();
	}
	public void Attack(){
		bulletTimer = bulletTimer + Time.deltaTime;
		
		if(bulletTimer >= shootInterval){
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize();

			GameObject bulletClone;
			bulletClone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

			bulletTimer = 0;
		}
	}
	public void Move(){
		if(Mathf.Abs(target.transform.position.x-transform.position.x) > 0.1){
			Vector2 direction = target.transform.position - transform.position;
			direction.y = 0;
			direction.Normalize();

			gameObject.GetComponent<Rigidbody2D>().velocity = direction * 2;
		}
		else{
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
		}
	}
	public void Damage(int damage){
		//animator.SetTrigger("Heat");
		SoundManager.instance.mainSwitch("damagedSound", true);
		curHp = curHp - damage;
		GameObject dummyEffect;
		dummyEffect = Instantiate(effectList[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		dummyEffect.transform.parent = this.gameObject.transform;
		if(curHp <= 0){
			GameObject.Instantiate(effectList[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			Destroy(gameObject);
		}
	}
}
